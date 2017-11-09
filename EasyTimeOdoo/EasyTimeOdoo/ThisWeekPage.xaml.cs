using EasyTimeOdoo.Model;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EasyTimeOdoo.Modal;
using System.Diagnostics;

namespace EasyTimeOdoo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThisWeekPage : ContentPage
    {
        MenuItem starterItem;
        Stopwatch sw;
        ObservableCollection<Activity> _Activity;
        string endDate;
        string startDate;
        int id = 7;
        String Url = "https://ucn.odoologin.dk";
        HttpClient _client = new HttpClient();

        public ThisWeekPage()
        {
            InitializeComponent();
            sw = new Stopwatch();
            getWeekDates();
            Url = Url + "/get/date/tasks?user_id=" + id + "&start=" + startDate + "&end=" + endDate;
        }

        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var activities = JsonConvert.DeserializeObject<TaskResponse>(content);
            _Activity = new ObservableCollection<Activity>(activities.data);
            listView.ItemsSource = _Activity;

            base.OnAppearing();
        }

        public void getWeekDates()
        {
            switch (DateTime.Now.ToString("ddd"))
            {
                case "Mon":
                    startDate = DateTime.Now.ToString("dd-MM-yyyy");
                    endDate = DateTime.Now.AddDays(+6).ToString("dd-MM-yyyy");
                    return;

                case "Tue":
                    startDate = DateTime.Now.AddDays(-1).ToString("dd-MM-yyyy");
                    endDate = DateTime.Now.AddDays(+5).ToString("dd-MM-yyyy");
                    return;

                case "Wed":
                    startDate = DateTime.Now.AddDays(-2).ToString("dd-MM-yyyy");
                    endDate = DateTime.Now.AddDays(+4).ToString("dd-MM-yyyy");
                    return;

                case "Thu":
                    startDate = DateTime.Now.AddDays(-3).ToString("dd-MM-yyyy");
                    endDate = DateTime.Now.AddDays(+3).ToString("dd-MM-yyyy");
                    return;

                case "Fri":
                    startDate = DateTime.Now.AddDays(-4).ToString("dd-MM-yyyy");
                    endDate = DateTime.Now.AddDays(+2).ToString("dd-MM-yyyy");
                    return;

                case "Sat":
                    startDate = DateTime.Now.AddDays(-5).ToString("dd-MM-yyyy");
                    endDate = DateTime.Now.AddDays(+1).ToString("dd-MM-yyyy");
                    return;

                case "Sun":
                    startDate = DateTime.Now.AddDays(-6).ToString("dd-MM-yyyy");
                    endDate = DateTime.Now.ToString("dd-MM-yyyy");
                    return;
            }
        }

        // Timer eventhandler
        void Start_clicked(object sender, System.EventArgs e)
        {
            TimerBtn_Clicked(sender, e);
        }

        // Timer toggle logic
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
                var elapsed = Math.Round(sw.Elapsed.TotalHours, 3).ToString();
                sw.Reset();

                if (starterItem != null)
                {
                    UpdateListItem((Activity)starterItem.BindingContext, elapsed);
                }
                else
                {
                    await Navigation.PushModalAsync(new NewActivityModal(elapsed));
                }
            }
        }

        // Add timesheet for swipe timers on existing tasks
        async void UpdateListItem(Activity item, string elapsed)
        {
            string url = "https://ucn.odoologin.dk/timesheet/add?task_id=" +
                item.task_id + "&user_id=" + id + "&timesheet_date=" +
                    DateTime.Now.ToString("dd-MM-yyyy") + "&timesheet_description=" +
                    "hej" + "&timesheet_duration=" + elapsed;
            await _client.PostAsync(url, null);
        }

        // Update timer lbl
        bool UpdateLabel()
        {
            TimerLbl.Text = sw.Elapsed.ToString(@"hh\:mm\:ss");
            return true;
        }

        // Cell tap eventhandler
        void ViewCell_Tapped(object sender, System.EventArgs e)
        {
            ViewCell vc = (ViewCell)sender;
            Activity item = (Activity)vc.BindingContext;
            Navigation.PushModalAsync(new ActivityModal(item));
        }
    }
}