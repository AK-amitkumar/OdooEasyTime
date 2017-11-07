using System;
using System.Collections.Generic;
using EasyTimeOdoo.Model;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace EasyTimeOdoo.Modal
{
    public partial class ActivityModal : ContentPage
    {
        Activity item;

        public ActivityModal(Activity item)
        {
            this.item = item;
            InitializeComponent();

            Tasklbl.Text = item.task_name;
            Projectlbl.Text = item.project_name;
            Startlbl.Text = item.task_start_date;
            Endlbl.Text = item.task_end_date;
            //Timelbl.Text = // 
            Elapsedlbl.Text = item.task_total_hours.ToString();
        }

        async void AnnullerBtn_clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void GemBtm_clicked(object sender, System.EventArgs e)
        {
            // push material lines to API
        }

        void AddMaterialBtn_clicked(object sender, System.EventArgs e)
        {
            // Add material to a list??
        }

        async void AddPictureBtn_clicked(object sender, System.EventArgs e)
        {
            var scanPage = new ZXingScannerPage();
            // Navigate to our scanner page
            await Navigation.PushAsync(scanPage);
        }
    }
}
