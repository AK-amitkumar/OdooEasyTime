using EasyTime.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyTime.Modal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewActivityModal : ContentPage
    {
        ObservableCollection<Activity> Tasks;

        public NewActivityModal(ObservableCollection<Activity> _People)
        {
            InitializeComponent();
            Tasks = _People;
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            Activity c = new Activity { TaskName = nameEntry.Text, ProjectName = statusEntry.Text };
            Tasks.Add(c);
            await Navigation.PopModalAsync();
        }

    }
}