using System.Windows.Input;
using AP4test.Models;
using AP4test.ViewModels.AccueilConnecter.Config;
using Xamarin.Forms;

namespace AP4test.ViewModels.AccueilConnecter.Accueil
{
    public class AccueilConnecterViewModel : BaseVueModele
    {
        #region Attributs

        public string ButtonListFlashText { get; }

        public string ButtonListInverserText { get; }

        public string ButtonListClassiqueText { get; }

        #endregion

        #region Constructeurs

        public AccueilConnecterViewModel()
        {
            Title = AccueilConnecterLang.Title;
            ButtonListClassiqueText = AccueilConnecterLang.ButtonListClassiqueText;
            ButtonListInverserText = AccueilConnecterLang.ButtonListInverserText;
            ButtonListFlashText = AccueilConnecterLang.ButtonListFlashText;
            TypeEnchere.CollClasse.Clear();
        }

        #endregion

        #region Getters/Setters

        public ICommand CommandListClassique => new Command(() => Disptach(new TypeEnchere("1", "classique")));
        public ICommand CommandListInverser => new Command(() => Disptach(new TypeEnchere("4", "inverse")));
        public ICommand CommandListFlash => new Command(() => Disptach(new TypeEnchere("3", "flash")));

        #endregion

        #region Methodes

        async void Disptach(TypeEnchere typeEnchere)
        {
            await Shell.Current.GoToAsync($"ListEnchereSampleView?IdTypeEnchere={typeEnchere.Id}");
        }

        #endregion
    }
}