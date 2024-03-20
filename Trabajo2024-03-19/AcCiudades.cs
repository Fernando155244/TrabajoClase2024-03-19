using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace Trabajo2024_03_19
{
    [Activity(Label = "AcCiudades")]
    public class AcCiudades : Activity
    {
        DataSet ds;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Ciudades);
            clsDatos datos = new clsDatos();

            ImageView imgBandera = this.FindViewById<ImageView>(Resource.Id.imgPais);
            TextView lblPais = this.FindViewById<TextView>(Resource.Id.lblPais);
            //id = this.Intent.GetIntExtra("idc", 0);
            lblPais.Text = this.Intent.GetStringExtra("pais").ToString();
            /*Url url = new Url(this.Intent.GetStringExtra("bandera").ToString());
            byte[] byteArray = Encoding.UTF8.GetBytes(this.Intent.GetStringExtra("bandera").ToString());
            MemoryStream stream = new MemoryStream(byteArray);
            Android.Graphics.Bitmap bmt1 = BitmapFactory.DecodeStream(stream);
            imgBandera.SetImageBitmap(bmt1);*/


        }
    }
}