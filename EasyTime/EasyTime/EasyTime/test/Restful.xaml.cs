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

namespace EasyTime.test
{
    public class Project
    {
        public string project_name { get; set; }
        public int ProjectId { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Restful : ContentPage
    {
        private const string Url = "https://ucn.odoologin.dk/get/projects";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<Project> _projects;
        public Restful()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            int firstDataIx = content.IndexOf('[');
            int lastDataIx = content.IndexOf(']');
            string content2 = content.Substring(firstDataIx, (lastDataIx - firstDataIx + 1));

            var projects = JsonConvert.DeserializeObject<List<Project>>(content2);

            _projects = new ObservableCollection<Project>(projects);
            projectsListView.ItemsSource = _projects;

            base.OnAppearing();
        }
    }
}