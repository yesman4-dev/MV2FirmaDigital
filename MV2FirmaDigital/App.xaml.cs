using MV2FirmaDigital.Controllers;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MV2FirmaDigital
{
    public partial class App : Application
    {
        static FirmaDB BaseDatos;

        public static FirmaDB BaseDatosObject
        {
            get
            {
                if (BaseDatos == null)
                {
                    BaseDatos = new FirmaDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FirmasDB.db3"));
                }
                return BaseDatos;
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
