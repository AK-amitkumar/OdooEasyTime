using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//https://ucn.odoologin.dk/get/date/tasks?user_id=7&start=19-09-2016&end=31-12-2017

namespace EasyTimeOdoo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThisWeekPage : ContentPage
    {
        public ThisWeekPage()
        {
            InitializeComponent();
        }
    }
}