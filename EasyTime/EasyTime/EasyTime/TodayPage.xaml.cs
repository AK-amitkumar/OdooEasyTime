using EasyTime.Modal;
using EasyTime.Model;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EasyTime
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodayPage : ContentPage
    {
        Stopwatch sw;
        const string Url = "http://localhost:3000/tasks/";
        HttpClient _client = new HttpClient();
        ObservableCollection<Activity> _Activity;
        List<Activity> activities;

        public TodayPage()
        {
            InitializeComponent();
			sw = new Stopwatch();
            _Activity =  new ObservableCollection<Activity>();
            listView.ItemsSource = _Activity;
            activities = new List<Activity>();
        }

        // Populating listview with Activities from REST API, where the current date is within the date span.
        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);

            int firstDataIx = content.IndexOf('[');
            int lastDataIx = content.IndexOf(']');
            string contentFormatted = content.Substring(firstDataIx, (lastDataIx - firstDataIx + 1));

            activities = JsonConvert.DeserializeObject<List<Activity>>(contentFormatted);
			DateTime currentDate = Convert.ToDateTime(DateTime.Today);

            foreach (var activity in activities)
            {
                if (activity.Startdate >= currentDate && currentDate <= activity.EndDate){
                    _Activity.Add(activity);
                }
            }
            base.OnAppearing();
        }

        // Eventhandler - create new activity without elapsed timed
        void AddNewTask_Clicked(object sender, EventArgs e)
        {
            CreateListItem("0"); 
        }

		void CreateListItem(String elapsed)
		{
            Navigation.PushModalAsync(new NewActivityModal(_Activity, activities, elapsed));
		}

		// Timer toggle event

		void TimerBtn_Clicked(object sender, EventArgs e)
		{
			if (TimerBtn.Text == "Start")
			{
				sw.Start();
				TimerBtn.Text = "Stop";
				TimerBtn.BackgroundColor = Color.Red;
				Device.StartTimer(new TimeSpan(0, 0, 1), UpdateLabel);
			}
			else
			{
				sw.Stop();
				TimerBtn.Text = "Start";
				TimerBtn.BackgroundColor = Color.Green;
				var elapsed = sw.Elapsed.ToString(@"hh\:mm\:ss");
				CreateListItem(elapsed);
				sw.Reset();
			}
		}

		bool UpdateLabel()
		{
			TimerLbl.Text = sw.Elapsed.ToString(@"hh\:mm\:ss");
			return true;
		}

        //private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
        //    var test = (Label)sender;
        //    test.Text = "det virker!";
        //}

    }
}