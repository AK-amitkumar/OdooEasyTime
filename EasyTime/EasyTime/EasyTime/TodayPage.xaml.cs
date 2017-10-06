using EasyTime.Modal;
using EasyTime.Model;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace EasyTime
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodayPage : ContentPage
    {
        Stopwatch sw;

        public TodayPage()
        {
            InitializeComponent();
            listView.ItemsSource = _People;
			sw = new Stopwatch();
        }

        public ObservableCollection<Activity> _People = new ObservableCollection<Activity>
        {
            new Activity {TaskName ="Tester1", ProjectName="Tester"},
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

		void CreateListItem(String elapsed)
		{
			//Navigation.PushModalAsync(new ExistingTaskModal(_People, elapsed));

			//_People.Add(new Activity { Name = elapsed, Status = "Hej" });
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

		bool UpdateLabel()
		{
			TimerLbl.Text = sw.Elapsed.ToString(@"hh\:mm\:ss");
			return true;
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var test = (Label)sender;
            test.Text = "det virker!";
        }
    }
}