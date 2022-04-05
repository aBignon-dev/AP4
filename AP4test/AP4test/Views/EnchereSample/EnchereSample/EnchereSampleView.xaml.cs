using AP4test.ViewModels.EnchereSample.EnchereSample;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP4test.Views.EnchereSample.EnchereSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnchereSampleView
    {
        EnchereSampleViewModel _viewModel;

        public EnchereSampleView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new EnchereSampleViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _viewModel.OnDisappearing();
        }
    }
}