using System;
using Xamarin.Forms;

namespace AP4test.ViewModels.EnchereSample.EndEnchere
{
    [QueryProperty(nameof(IdEnchere), nameof(IdEnchere))]

    public class WinViewModel : BaseVueModele
    {
        private string _idEnchere;

        public string IdEnchere
        {
            get => _idEnchere;
            set => _idEnchere = Uri.UnescapeDataString(value ?? string.Empty);
        }
    }
}