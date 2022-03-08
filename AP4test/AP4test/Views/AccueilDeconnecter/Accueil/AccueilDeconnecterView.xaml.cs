using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP4test.ViewModels.AccueilDeconnecter;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP4test.Views.AccueilDeconnecter.Accueil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccueilDeconnecterView : ContentPage
    {
        readonly AccueilDeconnecterViewModel vueModele;

        public AccueilDeconnecterView()
        {
            InitializeComponent();
            BindingContext = vueModele = new AccueilDeconnecterViewModel();
        }
    }
}