using EasyTime.Modal;
using EasyTime.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyTime
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrivingPage : ContentPage
    {
        public DrivingPage()
        {
            InitializeComponent();
            listview.ItemsSource = _activeDrive;
            lblDate.Text = DateTime.Now.ToString();
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