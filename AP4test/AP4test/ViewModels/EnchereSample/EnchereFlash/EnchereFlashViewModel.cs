using System;
using AP4test.Config;
using Xamarin.Forms;

namespace AP4test.ViewModels.EnchereSample.EnchereFlash
{
    [QueryProperty(nameof(IdEnchere), nameof(IdEnchere))]
    public class EnchereFlashViewModel : BaseVueModele
    {
        private string _idEnchere;

        public string IdEnchere
        {
            get => _idEnchere;
            set => _idEnchere = Uri.UnescapeDataString(value ?? string.Empty);
        }


        #region Methodes Load

        /// <summary>
        /// Append when the User reload or load the current page
        /// </summary>
        public void OnAppearing()
        {
            ViewModelConfig.OnCancel = false;
            IsBusy = true;
        }

        /// <summary>
        /// Append when the user leave the current page
        /// </summary>
        public void OnDisappearing()
        {
            ViewModelConfig.OnCancel = true;
        }

        #endregion
    }
}