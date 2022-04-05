using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP4test.Models;
using AP4test.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP4test.Views.AccueilDeconnecter.Connexion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnexionView : ContentPage
    {
        public ConnexionView()
        {
            InitializeComponent();
        }

        private void BtnConnexion_Clicked(object sender, EventArgs e)
        {
        }
    }
}