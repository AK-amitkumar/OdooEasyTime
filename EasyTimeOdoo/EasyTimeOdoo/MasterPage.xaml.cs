using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EasyTimeOdoo
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new TodayPage());
        }

        void TodayClicked(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new TodayPage());
            IsPresented = false;
        }

        void WeekClicked(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new ThisWeekPage());
            IsPresented = false;
        }

        void DrivingClicked(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new DrivingPage());
            IsPresented = false;
        }

        void StatsClicked(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new StatisticsPage());
            IsPresented = false;
        }
    }
}
