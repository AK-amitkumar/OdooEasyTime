using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EasyTimeOdoo.Model;
using Xamarin.Forms;

namespace EasyTimeOdoo.Modal
{
    public partial class NewActivityDriveModal : ContentPage
    {
        ObservableCollection<ActivityDriving> _activityDriveList;
        public NewActivityDriveModal(ObservableCollection<ActivityDriving> _activityDrive)
        {

            InitializeComponent();
            _activityDriveList = _activityDrive;
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            ActivityDriving ad = new ActivityDriving { Title = titleEntry.Text, Description = descriptionEntry.Text, Distance = distanceEntry.Text, sDate = dateEntry.Text };
            _activityDriveList.Add(ad);
            await Navigation.PopModalAsync();
        }
    }
}
