using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EasyTimeOdoo.Model;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace EasyTimeOdoo.Modal
{
    public partial class ActivityModal : ContentPage
    {
        Activity item;
        ObservableCollection<MaterialLine> materials;
        Dictionary<string, string> barcode;

        public ActivityModal(Activity item)
        {
            InitializeComponent();

            // Dummy data 
            barcode = new Dictionary<string, string>();
            barcode.Add("5760466976459", "Mathilde Kakao");
            barcode.Add("5741000133491", "Royal Classic");
            // Dummy data 



            materials = new ObservableCollection<MaterialLine>();
            materials.Add(new MaterialLine { quantity = 1, product_id = "CannotGetMaterialsAPI" });

            materialList.ItemsSource = materials;
            this.item = item;

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

        async void AddMaterialBtn_clicked(object sender, System.EventArgs e)
        {
            var scannerPage = new ZXingScannerPage();
            // Navigate to our scanner page
            await Navigation.PushAsync(new NavigationPage(scannerPage));

            scannerPage.OnScanResult += (result) =>
            {
                scannerPage.IsScanning = false;
                ZXing.BarcodeFormat barcodeFormat = result.BarcodeFormat;
                string type = barcodeFormat.ToString();
                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopModalAsync();
                    AddMaterialLine(result.ToString());
                });
            };
        }

        void AddPictureBtn_clicked(object sender, System.EventArgs e)
        {
            // add picture logic 
        }

        void AddMaterialLine(string barcodeNumber){
            string name = barcode[barcodeNumber];

            materials.Add(new MaterialLine{quantity=1, product_id=barcodeNumber, description=name});
            
            
        }
    }
}
