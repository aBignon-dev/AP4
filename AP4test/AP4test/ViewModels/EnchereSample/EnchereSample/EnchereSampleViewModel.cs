using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using AP4test.Config;
using AP4test.Models;
using AP4test.Services;
using AP4test.ViewModels.AccueilDeconnecter.Config;
using AP4test.ViewModels.EnchereSample.Config;
using AP4test.Views.AccueilDeconnecter.Inscription;
using Xamarin.Forms;

namespace AP4test.ViewModels.EnchereSample.EnchereSample
{
    [QueryProperty(nameof(IdEnchere), nameof(IdEnchere))]
    public class EnchereSampleViewModel : BaseVueModele
    {
        #region Attributs

        private readonly Api _apiServices = new Api();
        private string _idEnchere;
        private bool _firstloaded;
        private double _timeleft;
        private string _lastOfferText;
        private User _userConnected;
        private Enchere _enchereSelected;
        private string _actualPriceText;
        private string _offerPlaceholder;
        private string _textOffer;
        private string _alertMessage= String.Empty;
        private double _coefficient;
        private bool _isInvited;
        private bool _isConnected;
        private string _informationOfferText;
        private string _informationOfferInvitedText;



        #endregion

        #region Constructeurs

        public EnchereSampleViewModel()
        {
            LabelAddText();
            Encheris = new ObservableCollection<Encherir>();
            Encheris.Add(new Encherir(0, "Aucune offre"));
            LoadItemsCommand = new Command(ExecuteLoad);
            UserConnected = User.GetAllItemsSqlite().Result[0];
        }

        #endregion

        #region Getters/Setters



        public double TimeLeftPercent
        {
            get => _timeleft;
            set => SetProperty(ref _timeleft, value);
        }
        public string LastOfferText
        {
            get => _lastOfferText;
            set => SetProperty(ref _lastOfferText, value);
        }
        public User UserConnected
        {
            get => _userConnected;
            set => SetProperty(ref _userConnected, value);
        }
        public Enchere EnchereSelected
        {
            get => _enchereSelected;
            set => SetProperty(ref _enchereSelected, value);
        }
        public string ActualPriceText
        {
            get => _actualPriceText;
            set => SetProperty(ref _actualPriceText, value);
        }
        public string OfferPlaceholder
        {
            get => _offerPlaceholder;
            set => SetProperty(ref _offerPlaceholder, value);
        }
        public string TextOffer
        {
            get => _textOffer;
            set => SetProperty(ref _textOffer, value);
        }
        public string AlertMessage
        {
            get => _alertMessage;
            set => SetProperty(ref _alertMessage, value);
        }
        public double Coefficient
        {
            get => _coefficient;
            set => SetProperty(ref _coefficient, value);
        }
        
        public string IdEnchere
        {
            get => _idEnchere;
            set => _idEnchere = Uri.UnescapeDataString(value ?? string.Empty);
        }
        public string InformationOfferText
        {
            get => _informationOfferText;
            set => SetProperty(ref _informationOfferText, value);
        }
        public string InformationOfferInvitedText
        {
            get => _informationOfferInvitedText;
            set => SetProperty(ref _informationOfferInvitedText, value);
        }
        public bool IsInvited
        {
            get => _isInvited;
            set => SetProperty(ref _isInvited, value);
        }
        public bool IsConnected
        {
            get => _isConnected;
            set => SetProperty(ref _isConnected, value);
        }
        
        public Command LoadItemsCommand { get; }

        public ObservableCollection<Encherir> Encheris { get; set; }
        public ICommand CommandInscription => new Command(() => Shell.Current.GoToAsync($"{nameof(InscriptionView)}"));
        public ICommand CommandOffer => new Command(CreateOffer);
        #endregion

        #region Methodes Load

        private async void ExecuteLoad()
        {
            if (!_firstloaded)
            {
                ExecuteFirstLoadCommand();
                LowerBlockEnable(UserConnected);
            }

            await ExecuteLoadEncherisCommand();
        }

        private void LabelAddText()
        {
            LastOfferText = EnchereSamplelang.LastOfferText;
            ActualPriceText = EnchereSamplelang.ActualPriceText;
        }

        private void LowerBlockEnable(User userConnected)
        {
            if (userConnected == null)
            {
                LowerBlockInviter();
                return;
            }

            LowerBlockConnected();
        }

        private void LowerBlockConnected()
        {
            OfferPlaceholder = EnchereSamplelang.OfferPlaceholder;
            TextOffer = String.Empty;
            IsInvited = false;
            IsConnected = true;

            if (EnchereSelected.TypeEnchere.Id == "1")
            {
                Coefficient = EnchereSampleConfig.PercentClassique+1;
                InformationOfferText = EnchereSamplelang.InformationOfferText
                    .Replace("%percent%", EnchereSampleConfig.PercentClassique * 100 + "")
                    .Replace("%action%", EnchereSamplelang.HigherOfferText);
                return;
            }

            Coefficient = 1-EnchereSampleConfig.PercentInverser;
            InformationOfferText = EnchereSamplelang.InformationOfferText
                .Replace("%percent%", EnchereSampleConfig.PercentInverser * 100 + "")
                .Replace("%action%", EnchereSamplelang.LowerOfferText);
        }

        private void LowerBlockInviter()
        {
            InformationOfferInvitedText = EnchereSamplelang.InformationOfferInvitedText;
            IsInvited = true;
            IsConnected = false;
        }

        private async Task ExecuteLoadEncherisCommand()
        {
            try
            {
                Encherir.CollOffer.Clear();
                Encheris.Clear();
                Encheris = await GetLastSixOffer(EnchereSelected.Id);
                if (Encheris.Count == 0)
                    Encheris.Add(new Encherir(0, "Aucune offre"));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


        public void ExecuteFirstLoadCommand()
        {
            try
            {
                foreach (var enchere in Enchere.CollEnchere)
                {
                    if (enchere.Id.ToString() == IdEnchere)
                        EnchereSelected = enchere;
                }

                TimeLeftPercent = Util.TimeUtil.TimeLeftPercent(EnchereSelected);
                Title = EnchereSamplelang.Title
                    .Replace("%type%", EnchereSelected.TypeEnchere.Nom)
                    .Replace("%produit%", EnchereSelected.NomRead);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                _firstloaded = true;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        #endregion

        #region Methodes API

        private async void CreateOffer()
        {
            Authorize();
            if (AlertMessage == String.Empty)
            {
                if (await PostOffer() != 0)
                {
                    IsBusy = true;
                    ExecuteLoad();
                    return;
                }

                AlertMessage = Lang.ErrorApi;
            }

            await Application.Current.MainPage.DisplayAlert(AccueilDeconnecterConfig.ErrorTitleInscription,
                AlertMessage, Lang.AlertCancel);
        }

        private async Task<ObservableCollection<Encherir>> GetLastSixOffer(int EnchereId)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add(ApiConfig.GetLastSixOffer_EnchereID, EnchereId.ToString());
            return await _apiServices.GetAllAsync(ApiConfig.GetLastSixOffer, Encherir.CollOffer, param);
        }

        private async Task<int> PostOffer()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add(ApiConfig.PostEncherir_IdUser, UserConnected.ID.ToString());
            param.Add(ApiConfig.PostEncherir_IdEnchere, EnchereSelected.Id.ToString());
            param.Add(ApiConfig.PostEncherir_Coefficient, Coefficient.ToString());
            param.Add(ApiConfig.PostEncherir_PrixEnchere, TextOffer);
            //TODO Check wath to do and if postofferWorkin fine
            return await _apiServices.PostAsync(ApiConfig.PostUser, param);
        }

        #endregion

        #region Methodes Authorize

        private void Authorize()
        {
            //TODO Add authorize for price (with k, m, mrd)
        }

        #endregion
    }
}