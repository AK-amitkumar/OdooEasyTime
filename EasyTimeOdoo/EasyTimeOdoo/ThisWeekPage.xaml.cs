using EasyTimeOdoo.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyTimeOdoo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThisWeekPage : ContentPage
    {
        ObservableCollection<Activity> _Activity;
        String Url = "https://ucn.odoologin.dk/get/date/tasks?user_id=7&start=19-09-2016&end=31-12-2017";
        HttpClient _client = new HttpClient();

        public ThisWeekPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var activities = JsonConvert.DeserializeObject<List<Activity>>(content);
            _Activity = new ObservableCollection<Activity>(activities);
            //listView.ItemsSource = _Activity;

            base.OnAppearing();
        }

        public String StartDate(String date)
        {
            switch (date)
            {
                case "Mon":
                    return DateTime.Now.ToString("dd/MM/yyyy");
                    break;

                case "Tue":
                    return DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                    break;

                case "Wed":
                    return DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy");
                    break;

                case "Thu":
                    return DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy");
                    break;

                case "Fri":
                    return DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy");
                    break;

                case "Sat":
                    return DateTime.Now.AddDays(-5).ToString("dd/MM/yyyy");
                    break;

                case "Sun":
                    return DateTime.Now.AddDays(-6).ToString("dd/MM/yyyy");
                    break;

                default:
                    return "Fejl";
                    break;
            }
        }

        public String EndDate(String date)
        {
            switch (date)
            {
                case "Mon":
                    return DateTime.Now.AddDays(+6).ToString("dd/MM/yyyy");
                    break;

                case "Tue":
                    return DateTime.Now.AddDays(+5).ToString("dd/MM/yyyy");
                    break;

                case "Wed":
                    return DateTime.Now.AddDays(+4).ToString("dd/MM/yyyy");
                    break;

                case "Thu":
                    return DateTime.Now.AddDays(+3).ToString("dd/MM/yyyy");
                    break;

                case "Fri":
                    return DateTime.Now.AddDays(+2).ToString("dd/MM/yyyy");
                    break;

                case "Sat":
                    return DateTime.Now.AddDays(+1).ToString("dd/MM/yyyy");
                    break;

                case "Sun":
                    return DateTime.Now.ToString("dd/MM/yyyy");
                    break;

                default:
                    return "Fejl";
                    break;
            }
        }
    }
}