using System.Windows.Input;
using AP4test.Views.AccueilDeconnecter.Connexion;
using AP4test.Views.AccueilDeconnecter.Inscription;
using AP4test.Views.NavBar;
using Xamarin.Forms;

namespace AP4test.ViewModels.AccueilDeconnecter.Accueil
{
    public class AccueilDeconnecterViewModel : BaseVueModele
    {
        #region Attributs

        #endregion

        #region Constructeurs

        public AccueilDeconnecterViewModel()
        {
        }

        #endregion

        #region Getters/Setters

        public ICommand CommandConnexion => new Command(() => Application.Current.MainPage = new ConnexionView());
        public ICommand CommandInscription => new Command(() => Application.Current.MainPage = new InscriptionView());
        public ICommand CommandInviter => new Command(() => Application.Current.MainPage = new InviterShell());

        #endregion

        #region Methodes

        #endregion
    }
}