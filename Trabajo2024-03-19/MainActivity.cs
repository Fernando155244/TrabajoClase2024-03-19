using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Data;
using System.Security.Policy;
using static Android.Icu.Text.Transliterator;

namespace Trabajo2024_03_19
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        DataSet ds;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            ListView paises = this.FindViewById<ListView>(Resource.Id.lsPaises);

            clsDatos datos = new clsDatos();
            ds = datos.cargarContactos();

            paises.Adapter = new miAdap(this, ds);
            paises.ItemClick += Paises_ItemClick;
        }

        private void Paises_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            clsDatos datos = new clsDatos();
            View celda = e.View;
            ImageView imgPais = celda.FindViewById<ImageView>(Resource.Id.imgTabPais);
            int id = Convert.ToInt32(ds.Tables[0].Rows[e.Position]["id"]);
            string pais = (ds.Tables[0].Rows[e.Position]["pais"]).ToString();
            string bmp1 =ds.Tables[0].Rows[e.Position]["bandera"].ToString();
            Intent sp = new Intent(this, typeof(AcCiudades));
            sp.PutExtra("pais", pais);
            sp.PutExtra("bandera", bmp1);
            sp.PutExtra("id", id);
            StartActivity(sp);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    internal class miAdap : BaseAdapter
    {
        private MainActivity mainActivity;
        private DataSet ds;

        public miAdap(MainActivity mainActivity, DataSet ds)
        {
            this.mainActivity = mainActivity;
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
                celda = mainActivity.LayoutInflater.Inflate(Resource.Layout.tabPaises, null);
            }
            ImageView imgPais = celda.FindViewById<ImageView>(Resource.Id.imgTabPais);
            TextView lblPais = celda.FindViewById<TextView>(Resource.Id.lblTabPais);
            Android.Graphics.Bitmap bmp1 = datos.descarga2(ds.Tables[0].Rows[position]["bandera"].ToString());
            lblPais.Text = ds.Tables[0].Rows[position]["pais"].ToString();
            imgPais.SetImageBitmap(bmp1);
            return celda;
        }
    }
}