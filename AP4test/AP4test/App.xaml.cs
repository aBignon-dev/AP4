
using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AP4test.Models;
using AP4test.Views.AccueilConnecter.NavBar;
using AP4test.Views.AccueilDeconnecter.Accueil;
using AP4test.Views.NavBar;
using Doctolibtest.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP4test
{
    public partial class App : Application
    {
        private static GestionDataBase _database;
        public ObservableCollection<User> Users = Database.GetItemsAsync<User>();
        public  App()
        {
            InitializeComponent();
            AccueilSelector(Users.Count);
                
        }

        public void AccueilSelector(int connected)
        {
            if (connected ==0)
                Application.Current.MainPage = new AccueilDeconnecterView();
            else
                Application.Current.MainPage = new ConnecterShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override  void OnResume()
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
