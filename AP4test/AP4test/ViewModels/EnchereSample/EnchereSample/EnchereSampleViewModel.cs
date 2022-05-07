using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using AP4test.Config;
using AP4test.Models;
using AP4test.Services;
using AP4test.Util;
using AP4test.ViewModels.EnchereSample.Config;
using AP4test.ViewModels.EnchereSample.EndEnchere;
using AP4test.Views.AccueilDeconnecter.Inscription;
using AP4test.Views.EnchereSample.EndEnchere;
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
        private string _lastOfferText = EnchereSamplelang.LastOfferText;
        private User _userConnected;
        private Enchere _enchereSelected;
        private string _actualPriceText = EnchereSamplelang.ActualPriceText;
        private string _offerPlaceholder;
        private string _textOffer;
        private string _alertMessage = String.Empty;
        private string _timeRemaining;
        private decimal _coefficient;
        private bool _isInvited;
        private bool _isConnected;
        private string _informationOfferText;
        private string _informationOfferInvitedText;
        private ObservableCollection<Encherir> _encheris;
        private ObservableCollection<Encherir> _twoToSixOffers;
        private Encherir _actualEncherir;

        #endregion

        #region Constructeurs

        public EnchereSampleViewModel()
        {
            Encheris = new ObservableCollection<Encherir>();
            TwoToSixOffers = new ObservableCollection<Encherir>();
            StandardOffer();
            LoadItemsCommand = new Command(ExecuteLoad);
            UserConnected = User.GetAllItemsSqlite().Result[0];
        }

        #endregion

        #region Getters/Setters

        public int PriceOffer { get; set; }

        public double TimeLeftPercent
        {
            get => _timeleft;
            set => SetProperty(ref _timeleft, value);
        }

        public string TimeRemaining
        {
            get => _timeRemaining;
            set => SetProperty(ref _timeRemaining, value);
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
            set
            {
                if (_textOffer != value)
                {
                    _textOffer = value;
                    OnPropertyChanged(nameof(TextOffer));
                }
            }
        }

        public string AlertMessage
        {
            get => _alertMessage;
            set => SetProperty(ref _alertMessage, value);
        }

        private decimal Coefficient
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

        public ObservableCollection<Encherir> Encheris
        {
            get => _encheris;
            set => SetProperty(ref _encheris, value);
        }

        public Encherir ActualEncherir
        {
            get => _actualEncherir;
            set => SetProperty(ref _actualEncherir, value);
        }

        public Command LoadItemsCommand { get; }


        public ObservableCollection<Encherir> TwoToSixOffers
        {
            get => _twoToSixOffers;
            set => SetProperty(ref _twoToSixOffers, value);
        }

        public ICommand CommandInscription => new Command(() => Shell.Current.GoToAsync($"{nameof(InscriptionView)}"));
        public ICommand CommandOffer => new Command(CreateOffer);

        #endregion

        #region Methodes Reload

        /// <summary>
        /// Load everything after the Constructor of EnchereSampleView is done
        /// If if is already loaded one time it only load The progressbar and actual Offers
        /// </summary>
        private async void ExecuteLoad()
        {
            if (!_firstloaded)
            {
                EnchereSelected = Enchere.GetEnchereSelected(IdEnchere);
                LowerBlockDispatch();
                TitleLoad();
                Encheris.RemoveAt(0);
            }

            ResetEntry();
            await ProgressBarLoad();
            await ExecuteLoadEncherisCommand();

            if (!_firstloaded)
            {
                StartTaskRun();
                _firstloaded = true;
            }
        }

        private void ResetEntry()
        {
            TextOffer = String.Empty;
        }

        /// <summary>
        /// Load Offers for the EnchereSelected
        /// If there is no Offers make a simple standard view
        /// </summary>
        private async Task ExecuteLoadEncherisCommand()
        {
            Encherir.CollOffer.Clear();
            var result = await GetLastSixOffer(EnchereSelected.Id);
            if (result.Count == 0 && ActualEncherir == null)
                StandardOffer();
            else
                Encheris = result;
            if (Encheris.Count != 0)
            {
                ActualEncherir = Encheris[0];
                Encheris.RemoveAt(0);
            }

            TwoToSixOffers = Encheris;
            IsBusy = false;
        }

        /// <summary>
        /// Display a standard offer depending on TypeofEnchere 
        /// </summary>
        private void StandardOffer()
        {
            if (EnchereSelected == null)
            {
                Encheris.Add(new Encherir(0, EnchereSamplelang.NoEnchere));
                return;
            }

            Encheris.Add(new Encherir((float) EnchereSelected.PrixDepart, EnchereSamplelang.NoEnchere));
        }

        /// <summary>
        /// Load the progression for the ProgressBar depending on the time left before Enchere ending
        /// </summary>
        private Task ProgressBarLoad()
        {
            TimeLeftPercent = TimeUtil.TimeLeftPercent(EnchereSelected);
            return Task.CompletedTask;
        }

        #endregion

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

        #region Methodes FirstLoad

        /// <summary>
        /// Dispatch the loading of the lower block depending if the user is connected or not
        /// </summary>
        private void LowerBlockDispatch()
        {
            if (UserConnected == null)
            {
                LowerBlockInviter();
                return;
            }

            LowerBlockConnected();
        }

        /// <summary>
        /// TODO Add commentary
        /// </summary>
        private void LowerBlockConnected()
        {
            OfferPlaceholder = EnchereSamplelang.OfferPlaceholder;
            TextOffer = String.Empty;
            IsConnected = true;

            if (EnchereSelected.TypeEnchere.Id == "1")
            {
                Coefficient = EnchereSampleConfig.PercentClassique + 1;
                InformationOfferText = EnchereSamplelang.InformationOfferText
                    .Replace("%percent%", (EnchereSampleConfig.PercentClassique * 100).ToString())
                    .Replace("%action%", EnchereSamplelang.HigherOfferText);
                return;
            }

            Coefficient = 1 - EnchereSampleConfig.PercentInverser;
            InformationOfferText = EnchereSamplelang.InformationOfferText
                .Replace("%percent%", (EnchereSampleConfig.PercentInverser * 100).ToString())
                .Replace("%action%", EnchereSamplelang.LowerOfferText);
        }

        private void LowerBlockInviter()
        {
            InformationOfferInvitedText = EnchereSamplelang.InformationOfferInvitedText;
            IsInvited = true;
        }

        private void TitleLoad()
        {
            Title = EnchereSamplelang.Title
                .Replace("%type%", EnchereSelected.TypeEnchere.Nom)
                .Replace("%produit%", EnchereSelected.NomRead);
        }

        /// <summary>
        /// Start all the task run
        /// </summary>
        private void StartTaskRun()
        {
            DelayedTask();
            NoDelayedTask();
        }

        private void DelayedTask()
        {
            Task.Run(async () =>
            {
                while (!ViewModelConfig.OnCancel)
                {
                    await Task.Delay(ViewModelConfig.TaskDelay);
                    await ExecuteLoadEncherisCommand();
                }
            });
        }

        private void NoDelayedTask()
        {
            Task.Run(async () =>
            {
                while (!ViewModelConfig.OnCancel)
                {
                    await ProgressBarLoad();
                    await TimeRemainingLoad();
                    await TimeDone();
                }
            });
        }

        private async Task TimeDone()
        {
            TimeSpan timeSpan = TimeUtil.TimeLeft(EnchereSelected);
            if (timeSpan.Ticks == 0)
            {
                ViewModelConfig.OnCancel = false;
                User winner = await GetGagnant();
                if (winner.IdApi == UserConnected.IdApi)
                {
                    await Shell.Current.GoToAsync(
                        $"{nameof(WinView)}?{nameof(WinViewModel.IdEnchere)}={EnchereSelected.Id.ToString()}");
                    return;
                }

                await Shell.Current.GoToAsync(
                    $"{nameof(LooseView)}");
            }
        }

        private Task TimeRemainingLoad()
        {
            TimeSpan timeSpan = TimeUtil.TimeLeft(EnchereSelected);
            TimeRemaining = timeSpan.Days + "J " + timeSpan.Hours + "h " + timeSpan.Minutes + "m " + timeSpan.Seconds +
                            "s ";
            return Task.CompletedTask;
        }

        #endregion

        #region Methodes API

        private async void CreateOffer()
        {
            AlertMessage = String.Empty;
            Authorize();
            if (AlertMessage == String.Empty)
            {
                Dictionary<int, string> result = await PostOffer();
                if (result.ContainsKey(0))
                {
                    IsBusy = true;
                    ExecuteLoad();
                    return;
                }

                ErrorLang(result[0]);
            }

            await Application.Current.MainPage.DisplayAlert(EnchereSamplelang.ErrorOffer,
                AlertMessage, Lang.AlertCancel);
        }

        private async Task<Dictionary<int, string>> PostOffer()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add(ApiConfig.PostEncherir_IdUser, UserConnected.IdApi.ToString());
            param.Add(ApiConfig.PostEncherir_IdEnchere, EnchereSelected.Id.ToString());
            param.Add(ApiConfig.PostEncherir_Coefficient, Coefficient.ToString(CultureInfo.CurrentCulture));
            param.Add(ApiConfig.PostEncherir_PrixEnchere, PriceOffer);
            return await _apiServices.PostAsync(ApiConfig.PostEncherir, param);
        }

        private async Task<ObservableCollection<Encherir>> GetLastSixOffer(int EnchereId)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add(ApiConfig.GetLastSixOffer_EnchereID, EnchereId.ToString());
            return await _apiServices.GetAllAsync(ApiConfig.GetLastSixOffer, Encherir.CollOffer, param);
        }

        private async Task<User> GetGagnant()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add(ApiConfig.GetGagnant_EnchereID, EnchereSelected.Id.ToString());
            return await _apiServices.GetOneAsync<User>(ApiConfig.GetGagnant, param);
        }

        #endregion

        #region Methodes Authorize

        private void Authorize()
        {
            int result = ValidateUtil.PriceFormatValidate(TextOffer);
            if (result == -1)
            {
                AlertMessage = EnchereSamplelang.ErrorOfferIncorrectFormat;
                return;
            }

            PriceOffer = result;
        }

        private void ErrorLang(string result)
        {
            switch (result)
            {
                case "PRICE_TOO_LOW":
                    AlertMessage = EnchereSamplelang.ErrorOfferApiTooLow;
                    break;
                case "PRICE_TOO_HIGH":
                    AlertMessage = EnchereSamplelang.ErrorOfferApiTooHigh;
                    break;
                default:
                    AlertMessage = Lang.ErrorApi;
                    break;
            }
        }

        #endregion
    }
}