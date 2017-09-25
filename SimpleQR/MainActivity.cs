using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ZXing.Mobile;
using System.Collections.Generic;

namespace SimpleQR
{
    [Activity(Label = "SimpleQR", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        MobileBarcodeScanner scanner;
        ListView ResultListView;
        List<string> ListViewValues;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            MobileBarcodeScanner.Initialize(Application);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Create a new instance of our Scanner
            scanner = new MobileBarcodeScanner();


            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.MyButton);
            Button ScanQR = FindViewById<Button>(Resource.Id.ScanQR);
            Button CreateQR = FindViewById<Button>(Resource.Id.CreateQR);
            ListViewValues = new List<string>();
            ResultListView = FindViewById<ListView>(Resource.Id.listView1);

            ScanQR.Click += async delegate
             {
                 //Tell our scanner to use the default overlay
                 scanner.UseCustomOverlay = false;

                 //We can customize the top and bottom text of the default overlay
                 //scanner.TopText = "Hold the camera up to the barcode\nAbout 6 inches away";
                 //scanner.BottomText = "Wait for the barcode to automatically scan!";

                 //Start scanning
                 var result = await scanner.Scan();

                 HandleScanResult(result);
             };

            CreateQR.Click += CreateQR_Click;

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }

        private void CreateQR_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(CreateQRActivity));
        }

        void HandleScanResult(ZXing.Result result)
        {
            string msg = "";

            if (result != null && !string.IsNullOrEmpty(result.Text))
                msg = result.Text;
            else
                msg = "Сканирование прекращено!";

            ListViewValues.Add(msg);
            ResultListView.Adapter = new ListViewAdapter(this, ListViewValues);
            //this.RunOnUiThread(() => Toast.MakeText(this, msg, ToastLength.Short).Show());
        }
       
    }
}

