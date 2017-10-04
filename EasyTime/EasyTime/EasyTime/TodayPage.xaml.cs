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
    public partial class TodayPage : ContentPage
    {
        public TodayPage()
        {
            InitializeComponent();
            listView.ItemsSource = _People;
        }

        public ObservableCollection<Activity> _People = new ObservableCollection<Activity>
        {
            new Activity {TaskName ="Tester1", ProjectName="Tester", TimeElapsed="11111"},
            new Activity {TaskName ="Tester2", ProjectName="Tester"},
            new Activity {TaskName ="Tester3", ProjectName="Tester"},
        };

        async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            var page = new NewActivityModal(_People);
            await Navigation.PushModalAsync(page);
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Test", "Dette er test", "OK", "Cancel");
        }

        private void TimerBtn_Clicked(object sender, EventArgs e)
        {
            //
        }
    }
}