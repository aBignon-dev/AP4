using AP4test.ViewModels.EnchereSample.EnchereSample;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP4test.Views.EnchereSample.EnchereSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnchereSampleView : ContentPage
    {
        public EnchereSampleView()
        {
            BindingContext = new EnchereSampleViewModel();
            InitializeComponent();
        }
    }
}