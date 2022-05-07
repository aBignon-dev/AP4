using System;
using System.Threading.Tasks;
using System.Windows.Input;
using AP4test.Config;
using AP4test.Models;
using AP4test.ViewModels.EnchereSample.Config;
using Xamarin.Forms;

namespace AP4test.ViewModels.EnchereSample.EndEnchere
{
    [QueryProperty(nameof(IdEnchere), nameof(IdEnchere))]
    public class WinViewModel : BaseVueModele
    {
        #region Attributs

        private string _idEnchere;
        private string _infoSecondLineText;
        private string _infoFirstLineText;
        private Enchere _enchereSelected;

        #endregion

        #region Constructeurs

        public WinViewModel()
        {
            Title = WinLang.Title;
            WonText = WinLang.WonText;
            GgText = WinLang.GGText;
            LoadItemsCommand = new Command(ExecuteLoad);
            ButtonSuivantText = WinLang.ButtonSuivantText;
        }

        #endregion

        #region Getters/Setters

        public Command LoadItemsCommand { get; }
        public string GgText { get; }

        public string InfoFirstLineText
        {
            get => _infoFirstLineText;
            set => SetProperty(ref _infoFirstLineText, value);
        }

        public string InfoSecondLineText
        {
            get => _infoSecondLineText;
            set => SetProperty(ref _infoSecondLineText, value);
        }

        public string WonText { get; }
        public string ButtonSuivantText { get; }

        public Enchere EnchereSelected
        {
            get => _enchereSelected;
            set => SetProperty(ref _enchereSelected, value);
        }

        public string IdEnchere
        {
            get => _idEnchere;
            set => _idEnchere = Uri.UnescapeDataString(value ?? string.Empty);
        }

        public ICommand ButtonSuivant => new Command(RedirectToBase);

        #endregion

        #region Methodes

        async void RedirectToBase()
        {
            await Shell.Current.GoToAsync($"Accueil");
        }

        #endregion

        #region Methodes Load

        private void ExecuteLoad()
        {
            EnchereSelected = Enchere.GetEnchereSelected(IdEnchere);
            InfoFirstLineText = WinLang.InfoFirstLineText
                .Replace("%produit%", EnchereSelected.Produit.Nom);
            InfoSecondLineText = WinLang.InfoSecondLineText
                .Replace("%magasin%", EnchereSelected.Magasin.Nom)
                .Replace("%ville%", EnchereSelected.Magasin.Ville);
        }

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