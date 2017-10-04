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
    public partial class FrontPage : ContentPage
    {
        private ObservableCollection<menuItems> _Menus;
        public FrontPage()
        {
            InitializeComponent();
            FillMenu();
        }

        public void FillMenu()
        {
            _Menus = new ObservableCollection<menuItems>
            {
                new menuItems{Name="Idag", Imageurl="http://lorempixel.com/100/100/business/1"},
                new menuItems{Name="Denne uge", Imageurl="http://lorempixel.com/100/100/business/2"},
                new menuItems{Name="Kørsel", Imageurl="http://lorempixel.com/100/100/business/3"},
                new menuItems{Name="Statistik", Imageurl="http://lorempixel.com/100/100/business/4"},
                new menuItems{Name="Synkronisering", Imageurl="http://lorempixel.com/100/100/business/5"},
            };
            MainMenuList.ItemsSource = _Menus;
        }

        async private void MainMenuList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //Dette er en midlertidig løsning
            var menu = e.Item as menuItems;
            if (menu.Name == "Idag")
            {
                await Navigation.PushAsync(new TodayPage());
            }
            if (menu.Name == "Denne uge")
            {
                await Navigation.PushAsync(new ThisWeekPage());
            }
            if (menu.Name == "Kørsel")
            {
                await Navigation.PushAsync(new DrivingPage());
            }
            if (menu.Name == "Statistik")
            {
                await Navigation.PushAsync(new StatisticsPage());
            }
            if (menu.Name == "Synkronisering")
            {
                await Navigation.PushAsync(new SynchronizePage());
            }
            MainMenuList.SelectedItem = null;
        }
    }
}