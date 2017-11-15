using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EasyTimeOdoo.Model;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;

namespace EasyTimeOdoo.Modal
{
    public partial class NewActivityDriveModal : ContentPage
    {
        
        ObservableCollection<Activity> _Activity;
        int userID = 7;
        string Url = "https://ucn.odoologin.dk/get/date/tasks?user_id=";
        HttpClient _client = new HttpClient();
        string elapsed;
        string distance; 

        string GoogleURL;
        string key = "AIzaSyDpst6HNkFNAyw_bl07FwVRpUOrLVNUIQ4";


        public NewActivityDriveModal(string elapsed, string originLong, string originLat, string destLong, string destLat)
        {
            InitializeComponent();

            Url = Url + userID + "&start=" + DateTime.Now.ToString("dd-MM-yyyy") + "&end=" + DateTime.Now.ToString("dd-MM-yyyy");
            GoogleURL = "https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins=" +
                originLat + "," + originLong + "&destinations=" +
                destLat + "," + destLong +
                "%7C&key=" + key;
            this.elapsed = elapsed;

            GetDistance();
        }

        async void GetDistance(){
            var content = await _client.GetStringAsync(GoogleURL);
            var mapRespone = JsonConvert.DeserializeObject<MapResponse>(content);
            distance = mapRespone.rows[0].elements[0].distance.text;
            lblDistance.Text = distance;

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

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
