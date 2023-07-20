using Ejercicio2_1_Grupo1.Controllers;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_1_Grupo1
{
    public partial class App : Application
    {
        static Controllers.DBVideos dBVIdeos;
        public static Controllers.DBVideos Instancia
        {
            get
            {
                if (dBVIdeos == null)
                {
                    String dbname = "dbVideos.db3";
                    String dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    String dbfulp = Path.Combine(dbpath, dbname);
                    dBVIdeos = new Controllers.DBVideos(dbfulp);
                }

                return dBVIdeos;
                ;
            }
        }

            public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}   







  