using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Xamarin.Forms;

namespace EasyTime.test
{
    public class User{
		public int id { get; set; }
		public string name { get; set; }
		public string address { get; set; }
    }

    public partial class Rest2 : ContentPage
    {
        const string url = "http://127.0.0.1:3000/users/get/1";
        HttpClient client = new HttpClient();
        ObservableCollection<User> source;


        public Rest2()
        {
            InitializeComponent();
        }

		protected override async void OnAppearing()
		{
			var content = await client.GetStringAsync(url);
			var users = JsonConvert.DeserializeObject<User>(content);

			source = new ObservableCollection<User>();
            source.Add(users);
            list.ItemsSource = source;

			base.OnAppearing();
		}
    }
}
