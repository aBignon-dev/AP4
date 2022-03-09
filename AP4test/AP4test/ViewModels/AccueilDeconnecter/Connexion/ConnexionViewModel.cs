using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using AP4test.Config;
using AP4test.Models;
using AP4test.Services;
using AP4test.Views.AccueilDeconnecter.Accueil;
using AP4test.Views.NavBar;
using Xamarin.Forms;

namespace AP4test.ViewModels.AccueilDeconnecter.Connexion
{
    public class ConnexionViewModel:BaseVueModele
    {
        #region Attributs
        private readonly Api _apiServices = new Api();
        private string _pass = String.Empty;
        private string _mail = String.Empty;
        #endregion

        #region Constructeurs
        public ConnexionViewModel()
        {

        }
        #endregion

        #region Getters/Setters
        public ICommand CommandRetour => new Command(() => Application.Current.MainPage = new AccueilDeconnecterView());
        public ICommand CommandConnexion => new Command(Connexion);
        public string Pass
        {
            get { return _pass; }
            set
            {
                if (_pass != value)
                {
                    _pass = value;
                    OnPropertyChanged(nameof(Pass));
                }
            }
        }
        public string Mail
        {
            get { return _mail; }
            set
            {
                if (_mail != value)
                {
                    _mail = value;
                    OnPropertyChanged(nameof(Mail));
                }
            }
        }

        #endregion

        #region Methodes


        private async void Connexion()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("email", Mail);
            param.Add("password", Pass);
            User user = await GetUserByMdpAndMail(param);
            if (user == null)
                await Application.Current.MainPage.DisplayAlert("Connexion Non Réussi",
                    "Veuillez vérifier les informations entrée !", "ok");
            else
            {
                
                Application.Current.MainPage = new ConnecterShell();
            }
        }

        public async Task<User> GetUserByMdpAndMail(Dictionary<string, object> param)
        {
            User user = await _apiServices.GetOneAsync<User>
                (ApiConfig.GetUserByMailAndPass, param);
            return user;
        }

        #endregion 
    }
}