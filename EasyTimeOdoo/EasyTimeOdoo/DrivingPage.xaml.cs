using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using EasyTimeOdoo.Modal;
using EasyTimeOdoo.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using System.Threading.Tasks;

namespace EasyTimeOdoo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrivingPage : ContentPage
    {
        
        Stopwatch sw;   

        string OriginLongitude;
        string OriginLatitude;
        string DestLongtitude;
        string DestLatitude;

        public DrivingPage()
        {
            InitializeComponent();
            listview.ItemsSource = _activeDrive;
            sw = new Stopwatch();
        }

        public ObservableCollection<ActivityDriving> _activeDrive = new ObservableCollection<ActivityDriving>
            {
                //new ActivityDriving{Title = "Odoo House", Description = "Møde", Distance = "14", sDate = "10-10-0217"},
                //new ActivityDriving{Title = "Odoo House", Description = "Mail opsætning", Distance = "7", sDate = "12-10-0217"}
            };


        void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Test", "Dette er test", "OK", "Cancel");
        }

        void CreateListItem(String elapsed)
        {
            //Navigation.PushModalAsync(new ExistingTaskModal(_People, elapsed));

            //_People.Add(new Activity { Name = elapsed, Status = "Hej"  });
        }

        ObservableCollection<Activity> GetTasks()
        {
            ObservableCollection<Activity> Tasks = new ObservableCollection<Activity>();
            return Tasks;
        }

        // Timer toggle event

        async void TimerBtn_Clicked(object sender, EventArgs e)
        {
            if (TimerBtn.Text == "Start")
            {
                sw.Start();
                await GetfirstPosition();
                TimerBtn.Text = "Stop";
                TimerBtn.BackgroundColor = Color.Red;
                Device.StartTimer(new TimeSpan(0, 0, 1), UpdateLabel);
            }
            else
            {
                sw.Stop();
                await GetSecondPosition();
                TimerBtn.Text = "Start";
                TimerBtn.BackgroundColor = Color.Green;
                var elapsed = sw.Elapsed.ToString(@"hh\:mm\:ss");

                var page = new NewActivityDriveModal(elapsed, OriginLongitude, OriginLatitude, DestLongtitude, DestLatitude);
                Navigation.PushModalAsync(page);
                sw.Reset();
            }
        }

        async
        Task
GetfirstPosition(){
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(1));

                OriginLongitude = position.Longitude.ToString();
                OriginLatitude = position.Latitude.ToString(); 

        }

        async
        Task
GetSecondPosition(){
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(1));

            DestLongtitude = position.Longitude.ToString();
            DestLatitude = position.Longitude.ToString();
        }


        bool UpdateLabel()
        {
            TimerLbl.Text = sw.Elapsed.ToString(@"hh\:mm\:ss");
            return true;
        }

        void Start_clickedAsync(object sender, System.EventArgs e)
        {
            TimerBtn_Clicked(sender, e);
        }

    }
}