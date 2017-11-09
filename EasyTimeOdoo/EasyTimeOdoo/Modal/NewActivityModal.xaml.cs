using EasyTimeOdoo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;

namespace EasyTimeOdoo.Modal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewActivityModal : ContentPage
    {
        ObservableCollection<Activity> _Activity;
        string endDate;
        string startDate;
        int userID = 7;
        string elapsed;
        String Url = "https://ucn.odoologin.dk";
        HttpClient _client = new HttpClient();

        public NewActivityModal(string elapsed)
        {
            getWeeks();
            this.elapsed = elapsed;
            InitializeComponent();
        }


        async void Handle_Tapped(object sender, System.EventArgs e)
        {
            ViewCell item = (ViewCell)sender;
            Activity item2 = (Activity)item.BindingContext;
            string url = "https://ucn.odoologin.dk/timesheet/add?task_id=" + item2.task_id + "&user_id=" + userID + "&timesheet_date=" + DateTime.Now.ToString("dd-MM-yyyy") + "&timesheet_description=" + "hej" + "&timesheet_duration=" + elapsed;
            await _client.PostAsync(url, null);

            await Navigation.PopModalAsync();
        }

        async void getWeeks(){
            getWeekDates();
            Url = Url + "/get/date/tasks?user_id=" + userID + "&start=" + startDate + "&end=" + endDate;


            var content = await _client.GetStringAsync(Url);
            var activities = JsonConvert.DeserializeObject<TaskResponse>(content);
            _Activity = new ObservableCollection<Activity>(activities.data);
            taskList.ItemsSource = _Activity;
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

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}