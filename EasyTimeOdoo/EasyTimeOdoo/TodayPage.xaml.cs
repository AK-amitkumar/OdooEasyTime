using EasyTimeOdoo.Model;
using EasyTimeOdoo.Modal;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyTimeOdoo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodayPage : ContentPage
    {
        ObservableCollection<Activity> _Activity;
        Stopwatch sw;
        int userID = 7;
        string Url = "https://ucn.odoologin.dk/get/date/tasks?user_id=";
        HttpClient _client = new HttpClient();
        MenuItem starterItem;


        //https://ucn.odoologin.dk/timesheet/add?task_id=20&user_id=7&timesheet_date=02-11-2017&timesheet_description=as&timesheet_duration=2

        public TodayPage()
        {
            InitializeComponent();
            Url = Url + userID + "&start=" + DateTime.Now.ToString("dd-MM-yyyy") + "&end=" + DateTime.Now.ToString("dd-MM-yyyy");           
            sw = new Stopwatch();
        }

        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var activities = JsonConvert.DeserializeObject<TaskResponse>(content);
            _Activity = new ObservableCollection<Activity>(activities.data);
            listView.ItemsSource = _Activity;            

            base.OnAppearing();
        }

        async void UpdateListItem(Activity item, string elapsed)
        {
            string url = "https://ucn.odoologin.dk/timesheet/add?task_id=" + item.task_id + "&user_id=" + userID + "&timesheet_date=" + DateTime.Now.ToString("dd-MM-yyyy") + "&timesheet_description=" + "hej" + "&timesheet_duration=" + elapsed;
            await _client.PostAsync(url, null);
        }

        // Timer toggle event

        async void TimerBtn_Clicked(object sender, EventArgs e)
        {
            if (sender is MenuItem)
            {
                starterItem = (MenuItem)sender;
            }

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
                var elapsed = Math.Round(sw.Elapsed.TotalHours,3).ToString();
                sw.Reset();

                if (starterItem != null)
                {
                    UpdateListItem((Activity)starterItem.BindingContext, elapsed);
                }
                else{
                    await Navigation.PushModalAsync(new NewActivityModal(elapsed));
                }
            }

        }

        bool UpdateLabel()
        {
            TimerLbl.Text = sw.Elapsed.ToString(@"hh\:mm\:ss");
            return true;
        }

        void Start_clicked(object sender, System.EventArgs e)
        {
            TimerBtn_Clicked(sender, e);
        }

        void ViewCell_Tapped(object sender, System.EventArgs e)
        {
            ViewCell vc = (ViewCell)sender;
            Activity item = (Activity)vc.BindingContext;
            Navigation.PushModalAsync(new ActivityModal(item));
        }
    }
}