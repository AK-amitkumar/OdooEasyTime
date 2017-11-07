using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using EasyTimeOdoo.Modal;
using EasyTimeOdoo.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace EasyTimeOdoo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrivingPage : ContentPage
    {

        Stopwatch sw;

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

        async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            var page = new NewActivityDriveModal(_activeDrive);
            await Navigation.PushModalAsync(page);
        }

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

        void TimerBtn_Clicked(object sender, EventArgs e)
        {
            if (TimerBtn.Text == "Start")
            {
                sw.Start();
                TimerBtn.Text = "Stop";
                TimerBtn.BackgroundColor = Color.Red;
                Device.StartTimer(new TimeSpan(0, 0, 1), UpdateLabel);
            }
            else
            {
                sw.Stop();
                TimerBtn.Text = "Start";
                TimerBtn.BackgroundColor = Color.Green;
                var elapsed = sw.Elapsed.ToString(@"hh\:mm\:ss");
                CreateListItem(elapsed);
                sw.Reset();
            }
        }

        async void openModal()
        {
            var NewActivityDriveModal = new NewActivityDriveModal();

        }

        bool UpdateLabel()
        {
            TimerLbl.Text = sw.Elapsed.ToString(@"hh\:mm\:ss");
            return true;
        }

        void Start_clicked(object sender, System.EventArgs e)
        {
            TimerBtn_Clicked(sender, e);
        }

    }
}