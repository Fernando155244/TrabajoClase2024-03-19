using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;

namespace Trabajo2024_03_19
{
    [Activity(Label = "clsDatos")]
    public class clsDatos : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public DataSet cargarContactos()
        {
            WebReference.Service1 ws = new WebReference.Service1();
            DataSet ds = new DataSet();
            ds = ws.CargaPaises();
            return ds;
        }
        public Bitmap descarga(string url)
        {
            WebClient wc = new WebClient();
            byte[] arr = wc.DownloadData(url);
            Bitmap bmp = BitmapFactory.DecodeByteArray(arr, 0, arr.Length);
            return bmp;
        }
    }
}