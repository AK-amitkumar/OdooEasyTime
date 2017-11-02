using System;
using System.Collections.ObjectModel;
using EasyTimeOdoo.Modal;
using EasyTimeOdoo.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyTimeOdoo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrivingPage : ContentPage
    {
        public DrivingPage()
        {
            InitializeComponent();
            listview.ItemsSource = _activeDrive;
        }

        public ObservableCollection<ActivityDriving> _activeDrive = new ObservableCollection<ActivityDriving>
            {
                new ActivityDriving{Title = "Odoo House", Description = "Møde", Distance = "14", sDate = "10-10-0217"},
                new ActivityDriving{Title = "Odoo House", Description = "Mail opsætning", Distance = "7", sDate = "12-10-0217"}
            };

        async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            var page = new NewActivityDriveModal(_activeDrive);
            await Navigation.PushModalAsync(page);
        }

    }
}