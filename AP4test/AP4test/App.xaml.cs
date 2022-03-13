
using System;
using AP4test.Views.AccueilDeconnecter.Accueil;
using Doctolibtest.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP4test
{
    public partial class App : Application
    {
        private static GestionDataBase _database;
        public App()
        {
            InitializeComponent();
            MainPage = new AccueilDeconnecterView();
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
        public static GestionDataBase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new GestionDataBase();
                }
                return _database;
            }
        }
    }
}
