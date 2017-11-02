using EasyTimeOdoo.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EasyTimeOdoo.Modal;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyTimeOdoo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodayPage : ContentPage
    {
        ObservableCollection<Activity> _Activity;
        Stopwatch sw;
        const string Url = "https://ucn.odoologin.dk/get/date/tasks?user_id=7&start=19-09-2016&end=31-12-2017";
        HttpClient _client = new HttpClient();

        //https://ucn.odoologin.dk/timesheet/add?task_id=20&user_id=7&timesheet_date=02-11-2017&timesheet_description=as&timesheet_duration=2

        public TodayPage()
        {
            InitializeComponent();
            sw = new Stopwatch();
        }
        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var activities = JsonConvert.DeserializeObject<List<Activity>>(content);
            _Activity = new ObservableCollection<Activity>(activities);
            listView.ItemsSource = _Activity;

            base.OnAppearing();
        }
        async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            var page = new NewActivityModal(_Activity);
            await Navigation.PushModalAsync(page);
        }
        void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Test", "Dette er test", "OK", "Cancel");
        }
        void CreateListItem(String elapsed)
        {
            //Navigation.PushModalAsync(new ExistingTaskModal(_People, elapsed));

            //_People.Add(new Activity { Name = elapsed, Status = "Hej" });
        }
        ObservableCollection<Activity> GetTasks()
        {
            ObservableCollection<Activity> Tasks = new ObservableCollection<Activity>();
            return Tasks;
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

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var test = (Label)sender;
            test.Text = "det virker!";
        }

    }
}