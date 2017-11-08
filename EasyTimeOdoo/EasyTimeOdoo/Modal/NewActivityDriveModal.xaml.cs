using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EasyTimeOdoo.Model;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace EasyTimeOdoo.Modal
{
    public partial class NewActivityDriveModal : ContentPage
    {
        ObservableCollection<Activity> _Activity;
        int userID = 7;
        string Url = "https://ucn.odoologin.dk/get/date/tasks?user_id=";
        HttpClient _client = new HttpClient();
        string elapsed;

        public NewActivityDriveModal(string elapsed)
        {
            Url = Url + userID + "&start=" + DateTime.Now.ToString("dd-MM-yyyy") + "&end=" + DateTime.Now.ToString("dd-MM-yyyy");
            this.elapsed = elapsed;
            InitializeComponent();
            
        }
        protected async override void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var activities = JsonConvert.DeserializeObject<TaskResponse>(content);
            _Activity = new ObservableCollection<Activity>(activities.data);
            listView.ItemsSource = _Activity;
            lblTime.Text = elapsed;

            base.OnAppearing();
        }
    }
}
