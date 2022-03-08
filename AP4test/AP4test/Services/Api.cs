using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AP4test.Config;
using Newtonsoft.Json;

namespace AP4test.Services
{
    internal class Api
    {
        private static readonly HttpClient ClientHttp = new HttpClient();
        /// <summary>
        /// Cette methode est générique
        /// Cette méthode permet de recuperer la liste de toutes les occurences de la table.
        /// 
        /// </summary>
        /// <typeparam name="T">la classe concernée</typeparam>
        /// <param name="paramUrl">l'adresse de l'API</param>
        /// <param name="param">la collection de classe concernee</param>
        /// public async void GetListe()
        ///{
        ///MaListeClients = await _apiServices.GetAllAsync<Client>("clients", Client.CollClasse);
        ///}
        /// <returns>la liste des occurences</returns>
        public async Task<ObservableCollection<T>> GetAllAsync<T>(string paramUrl,List<T>param)
        {
            try
            {
                var json = await ClientHttp.GetStringAsync(ApiConfig.BaseApiAddress + paramUrl);
                JsonConvert.DeserializeObject<List<T>>(json);    
                return GestionCollection.GetLists<T>(param);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<int> PostAsync<T>(T param, string paramUrl)
        {

            var jsonstring = JsonConvert.SerializeObject(param);
            try
            {
                var jsonContent = new StringContent(jsonstring, Encoding.UTF8, "application/json");
                var response = await ClientHttp.PostAsync(ApiConfig.BaseApiAddress + paramUrl, jsonContent);
                var content = await response.Content.ReadAsStringAsync();
                int nID;
                return int.TryParse(content, out nID) ? nID : 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<ObservableCollection<T>> GetOneAsync<T>(string paramUrl, List<T> param, T param2)
        {
            try
            {
                var jsonstring = JsonConvert.SerializeObject(param2);
                var jsonContent = new StringContent(jsonstring, Encoding.UTF8, "application/json");

                var response = await ClientHttp.PostAsync(ApiConfig.BaseApiAddress + paramUrl, jsonContent);
                var json = await response.Content.ReadAsStringAsync();
                JsonConvert.DeserializeObject<List<T>>(json);
                return GestionCollection.GetLists<T>(param);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
