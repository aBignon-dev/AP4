using AP4test.ViewModels.EnchereSample.EndEnchere;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP4test.Views.EnchereSample.EndEnchere
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WinView : ContentPage
    {
        private WinViewModel _viewModel;

        public WinView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new WinViewModel();
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