using System.Windows.Input;
using AP4test.Models;
using AP4test.ViewModels.AccueilConnecter.Config;
using AP4test.ViewModels.EnchereSample.ListEnchere;
using AP4test.Views.AccueilDeconnecter.Connexion;
using AP4test.Views.AccueilDeconnecter.Inscription;
using AP4test.Views.EnchereSample.ListEnchere;
using AP4test.Views.NavBar;
using Xamarin.Forms;

namespace AP4test.ViewModels.AccueilConnecter.Accueil
{
    public class AccueilConnecterViewModel : BaseVueModele
    {
        #region Attributs

        public string ButtonListFlashText { get; set; }

        public string ButtonListInverserText { get; set; }

        public string ButtonListClassiqueText { get; set; }

        #endregion

        #region Constructeurs

        public AccueilConnecterViewModel()
        {
            Title = AccueilConnecterLang.Title;
            ButtonListClassiqueText = AccueilConnecterLang.ButtonListClassiqueText;
            ButtonListInverserText = AccueilConnecterLang.ButtonListInverserText;
            ButtonListFlashText = AccueilConnecterLang.ButtonListFlashText;
        }



        #endregion

        #region Getters/Setters

        public ICommand CommandListClassique => new Command(() => Disptach(new TypeEnchere("1", "classique")));
        public ICommand CommandListInverser => new Command(() => Disptach(new TypeEnchere("2", "inverse")));
        public ICommand CommandListFlash => new Command(() => Disptach(new TypeEnchere("3", "flash")));

        #endregion

        #region Methodes
        async void Disptach(TypeEnchere typeEnchere)
        {
            //?IdTypeEnchere={typeEnchere.Id.ToString()}
            //?{nameof(ListEnchereSampleViewModel.IdTypeEnchere)}={typeEnchere.Id}
            var route = $"ListEnchereSampleView?IdTypeEnchere={typeEnchere.Id}";
           await Shell.Current.GoToAsync(route);
        }

        #endregion
    }
}