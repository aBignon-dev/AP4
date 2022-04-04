using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP4test.ViewModels.EnchereSample.EnchereFlash;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP4test.Views.EnchereSample.EnchereFlash
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnchereFlashView
    {
        EnchereFlashViewModel _viewModel;

        public EnchereFlashView()
        {
            InitializeComponent();
            BindingContext= _viewModel = new EnchereFlashViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
        protected override void OnDisappearing ()
        {
            base.OnDisappearing();
            _viewModel.OnDisappearing();
        }
    }
}