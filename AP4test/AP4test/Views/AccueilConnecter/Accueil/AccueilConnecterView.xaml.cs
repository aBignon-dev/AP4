using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP4test.ViewModels.AccueilConnecter.Accueil;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP4test.Views.AccueilConnecter.Accueil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class AccueilConnecterView : ContentPage
    {
        private AccueilConnecterViewModel _viewModel;
        public AccueilConnecterView()
        {
            InitializeComponent();
            
            BindingContext = _viewModel = new AccueilConnecterViewModel();
        }
    }
}