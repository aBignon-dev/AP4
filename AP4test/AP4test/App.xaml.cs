
using System;
using AP4test.Views.AccueilDeconnecter.Accueil;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP4test
{
    public partial class App : Application
    {

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
    }
}
