using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using AP4test.Config;
using AP4test.Models;
using AP4test.Services;
using AP4test.ViewModels.AccueilDeconnecter.Config;
using AP4test.Views.AccueilDeconnecter.Accueil;
using AP4test.Views.NavBar;
using Newtonsoft.Json.Serialization;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AP4test.ViewModels.AccueilDeconnecter.Inscription
{
    public class InscriptionViewModel:BaseVueModele
    {


        #region Attributs
        private readonly Api _apiServices = new Api();
        private string _mail= String.Empty;
        private string _pass= String.Empty;
        private string _photo= String.Empty;
        private string _pseudo= String.Empty;
        public string AlertMessage = String.Empty;

        #endregion

        #region Constructeurs

        #endregion

        #region Getters/Setters
        public ICommand CommandRetour => new Command(() => Application.Current.MainPage = new AccueilDeconnecterView());
        public ICommand CommandInscription => new Command(Inscription);
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
        public string Photo
        {
            get { return _photo; }
            set
            {
                if (_photo != value)
                {
                    _photo = value;
                    OnPropertyChanged(nameof(Pass));
                }
            }
        }
        public string Pseudo
        {
            get { return _pseudo; }
            set
            {
                if (_pseudo != value)
                {
                    _pseudo = value;
                    OnPropertyChanged(nameof(Pass));
                }
            }
        }
        #endregion

        #region Methodes
        private async void Inscription()
        {
            Authorize();
            if (AlertMessage==String.Empty)
            {
                User user = new User(Pseudo, Photo, Pass, Mail);
                if (await PostUser(user) != 0)
                {
                    await User.AjoutItemSqlite(user);
                    Application.Current.MainPage = new ConnecterShell();
                    AlertMessage = AccueilDeconnecterConfig.ErrorApi;
                }
            }
            await Application.Current.MainPage.DisplayAlert(AccueilDeconnecterConfig.ErrorTitleInscription,
                AlertMessage, AccueilDeconnecterConfig.AlertCancel);
        }
        /// <summary>
        /// Méthode vérifiant que tout les champs de saisie ont une valeur correct
        /// </summary>
        private void Authorize()
        {
            RemiseAZeroTestBon();
            TestChampVide();
            if(AlertMessage ==String.Empty)
                TestChampValide();
        }

        private void TestChampVide()
        {
            if (Mail== String.Empty ||Pass ==String.Empty ||Photo== String.Empty ||Pseudo ==String.Empty  )
                AlertMessage = AccueilDeconnecterConfig.ErrorFieldEmpty;
        }

        private void TestChampValide()
        {
            if (!IsValidEmail())
                AlertMessage = AccueilDeconnecterConfig.ErrorEmailWrongFormat;
        }

        private bool IsValidEmail()
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(Mail);
                return addr.Address == Mail;
            }
            catch
            {
                return false;
            }        
        }

        private void RemiseAZeroTestBon()
        {
            AlertMessage = String.Empty;
        }

        private async Task<int> PostUser(User user)
        {
            return await _apiServices.PostAsync(user,ApiConfig.PostUser);
        }

        #endregion 
    }
}