using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AP4test.Config;
using AP4test.Models;
using AP4test.Services;
using AP4test.ViewModels.EnchereSample.Config;
using AP4test.ViewModels.EnchereSample.EnchereSample;
using AP4test.Views.EnchereSample.EnchereSample;
using Xamarin.Forms;

namespace AP4test.ViewModels.EnchereSample.ListEnchere
{
    [QueryProperty(nameof(IdTypeEnchere), nameof(IdTypeEnchere))]
    public class ListEnchereSampleViewModel : BaseVueModele
    {
        private readonly Api _apiServices = new Api();
        private Enchere _selectedItem;
        public ObservableCollection<Enchere> Encheres { get; set; }
        public Command LoadItemsCommand { get; }
        public Command<Enchere> ItemTapped { get; }

        public TypeEnchere TypeOfEncheres { get; set; }
        static string _idTypeEnchere = "";

        public ListEnchereSampleViewModel()
        {
            Encheres = new ObservableCollection<Enchere>();
            LoadItemsCommand = new Command(ExecuteLoad);
            ItemTapped = new Command<Enchere>(OnItemSelected);
        }

        private async void ExecuteLoad()
        {
            await ExecuteLoadItemsCommand(IdTypeEnchere);
        }


        public static string IdTypeEnchere
        {
            get => _idTypeEnchere;
            set { _idTypeEnchere = Uri.UnescapeDataString(value ?? string.Empty); }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Enchere SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        async Task ExecuteLoadItemsCommand(string typeEnchereId)
        {
            IsBusy = true;

            try
            {
                foreach (var typeEnchere in TypeEnchere.CollClasse)
                {
                    if (typeEnchere.Id == typeEnchereId)
                        TypeOfEncheres = typeEnchere;
                }

                Title = ListEnchereSampleLang.Title.Replace("%type%",TypeOfEncheres.Nom);
                Encheres.Clear();
                Enchere.CollEnchere.Clear();
                var encheres = await GetListeEncheresByType(typeEnchereId);
                foreach (var enchere in encheres)
                {
                    Encheres.Add(enchere);
                }
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

        private Task<ObservableCollection<Enchere>> GetListeEncheresByType(string typeEnchereId)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add(ApiConfig.GetEnchere_type, typeEnchereId);
            return _apiServices.GetAllAsync(ApiConfig.GetEnchere, Enchere.CollEnchere, param);
        }

        async void OnItemSelected(Enchere enchere)
        {
            if (enchere == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            // await Shell.Current.GoToAsync($"{nameof(EnchereSampleView)}?{nameof(EnchereSampleViewModel.ItemId)}={enchere.Id}");
        }
    }
}