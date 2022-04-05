using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP4test.Models;
using AP4test.ViewModels.EnchereSample.ListEnchere;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP4test.Views.EnchereSample.ListEnchere
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListEnchereSampleView : ContentPage
    {
        ListEnchereSampleViewModel _viewModel;

        public ListEnchereSampleView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ListEnchereSampleViewModel();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}