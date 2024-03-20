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
            int id = this.Intent.GetIntExtra("id",0)+1;
            ds = datos.cargarCiudades(id);

            ImageView imgBandera = this.FindViewById<ImageView>(Resource.Id.imgPais);
            ListView lsCiudades = this.FindViewById<ListView>(Resource.Id.lsCiudades);



            TextView lblPais = this.FindViewById<TextView>(Resource.Id.lblPais);
            //id = this.Intent.GetIntExtra("idc", 0);
            lblPais.Text = this.Intent.GetStringExtra("pais").ToString();
            /*Url url = new Url(this.Intent.GetStringExtra("bandera").ToString());
            byte[] byteArray = Encoding.UTF8.GetBytes(this.Intent.GetStringExtra("bandera").ToString());
            MemoryStream stream = new MemoryStream(byteArray);
            Android.Graphics.Bitmap bmt1 = BitmapFactory.DecodeStream(stream);
            imgBandera.SetImageBitmap(bmt1);*/

            lsCiudades.Adapter = new Adap(this,ds);



        }
    }

    internal class Adap : BaseAdapter
    {
        private AcCiudades acCiudades;
        private DataSet ds;

        public Adap(AcCiudades acCiudades, DataSet ds)
        {
            this.acCiudades = acCiudades;
            this.ds = ds;
        }

        public override int Count
        {
            get
            {
                return ds.Tables[0].Rows.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return "";
        }

        public override long GetItemId(int position)
        {
            return position;
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            clsDatos datos = new clsDatos();
            View celda = convertView;
            if (celda == null)
            {
                celda = acCiudades.LayoutInflater.Inflate(Resource.Layout.tabPaises, null);
            }
            ImageView imgciudad  = celda.FindViewById<ImageView>(Resource.Id.imgTabPais);
            TextView lblCiudad = celda.FindViewById<TextView>(Resource.Id.lblTabPais);
            Android.Graphics.Bitmap bmp1 = datos.descarga(ds.Tables[0].Rows[position]["foto"].ToString());
            lblCiudad.Text = ds.Tables[0].Rows[position]["capital"].ToString();
            imgciudad.SetImageBitmap(bmp1);
            return celda;
        }
    }
}