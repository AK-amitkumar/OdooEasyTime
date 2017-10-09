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
        const string Url = "http://localhost:3000/users/get/1";
        HttpClient _client = new HttpClient();
        ObservableCollection<Project> _projects;

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

            var projects = JsonConvert.DeserializeObject<List<Project>>(content);

            _projects = new ObservableCollection<Project>(projects);
            projectsListView.ItemsSource = _projects;

            base.OnAppearing();
        }

        async void OnAdd(object sender, EventArgs e)
        {
            var i = 1000;
            var project = new Project { project_name = "Title " + DateTime.Now.Ticks, ProjectId = i++};

            var content = JsonConvert.SerializeObject(project);
            await _client.PostAsync(Url, new StringContent(content));

            _projects.Add(project);
        }

        async void OnUpdate(object sender, EventArgs e)
        {
            var project = _projects[0];
            project.project_name += " UPDATED";

            var content = JsonConvert.SerializeObject(project);
            await _client.PutAsync(Url + "/" + project.ProjectId, new StringContent(content));
        }

        async void OnDelete(object sender, EventArgs e)
        {
            var project = _projects[0];

            await _client.DeleteAsync(Url + "/" + project.ProjectId);

            _projects.Remove(project);
        }
    }
}