using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SimpleQR
{
    [Activity(Label = "CreateQRActivity")]
    public class CreateQRActivity : Activity
    {
        ImageView imageBarcode;
        EditText textToCode;
        Button Code;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CreateQRCode);
            textToCode = FindViewById<EditText>(Resource.Id.editText1);
            Code = FindViewById<Button>(Resource.Id.btCreateQRCode);
            imageBarcode = FindViewById<ImageView>(Resource.Id.imageView1);

            Code.Click += Code_Click;
           
        }

        private void Code_Click(object sender, EventArgs e)
        {
            var barcodeWriter = new ZXing.Mobile.BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 300,
                    Height = 300
                }
            };
            var barcode = barcodeWriter.Write(textToCode.Text);

            imageBarcode.SetImageBitmap(barcode);
        }
    }
}