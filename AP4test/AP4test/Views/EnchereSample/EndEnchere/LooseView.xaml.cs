using AP4test.ViewModels.EnchereSample.EndEnchere;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP4test.Views.EnchereSample.EndEnchere
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LooseView : ContentPage
    {
        LooseViewModel _viewModel;

        public LooseView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new LooseViewModel();
        }
    }
}