using EasyTime.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyTime.Modal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewActivityModal : ContentPage
    {
        ObservableCollection<Activity> currentTasks;
        List<Activity> activities;
        string elapsedTime;

        public NewActivityModal(ObservableCollection<Activity> currentTasks, List<Activity> activities, string elapsedTime)
        {
            InitializeComponent();
            this.currentTasks = currentTasks;
            this.activities = activities;
            this.elapsedTime = elapsedTime;
        }

        //async void Button_Clicked(object sender, EventArgs e)
        //{
        //    Activity c = new Activity { TaskName = nameEntry.Text, ProjectName = statusEntry.Text };
        //    Tasks.Add(c);
        //    await Navigation.PopModalAsync();
        //}

        void SaveBtn_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        void CancelBtn_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }

}