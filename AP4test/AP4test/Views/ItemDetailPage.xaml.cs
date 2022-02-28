using AP4test.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AP4test.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}