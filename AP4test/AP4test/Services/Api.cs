using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AP4test.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AP4test.Services
{
    internal class Api
    {
        private static HttpClient ClientHttp = new HttpClient();

        ///  <summary>
        ///  Cette methode est générique
        ///  Cette méthode permet de recuperer la liste de toutes les occurences de la table.
        ///  
        ///  </summary>
        ///  <typeparam name="T">la classe concernée</typeparam>
        ///  <param name="paramUrl">l'adresse de l'API</param>
        ///  <param name="collectionReturn">la collection de classe concernee</param>
        /// <param name="parameters">Dictionnary with Key = param name  and Value = param value</param>
        ///  public async void GetListe()
        /// {
        /// MaListeClients = await _apiServices.GetAllAsync<Client>("clients", Client.CollClasse);
        /// }
        ///  <returns>la liste des occurences</returns>
        public async Task<ObservableCollection<T>> GetAllAsync<T>(string paramUrl, List<T> collectionReturn,
            Dictionary<string, object> parameters)
        {
            try
            {
                JObject getResult = JObject.Parse(GetJsonString(parameters));
                var jsonContent = new StringContent(getResult.ToString(), Encoding.UTF8, "application/json");
                var response = await ClientHttp.PostAsync(ApiConfig.BaseApiAddress + paramUrl, jsonContent);
                if (response == null)
                    return new ObservableCollection<T>();
                var json = await response.Content.ReadAsStringAsync();
                JsonConvert.DeserializeObject<List<T>>(json);
                return GestionCollection.GetLists<T>(collectionReturn);
            }
            catch (Exception)
            {
                return new ObservableCollection<T>();
            }
        }

        /// <summary>
        /// Post anything with the dictionnary
        /// </summary>
        /// <param name="paramUrl">Part of the URL of the API that need to be called</param>
        /// <param name="parameters">Parameters of wath is going to be in the body </param>
        /// <returns>the id of the object created</returns>
        public async Task<Dictionary<int, string>> PostAsync(string paramUrl, Dictionary<string, object> parameters)
        {
      //      try
       //     {
                Dictionary<int, string> result = new Dictionary<int, string>();
                JObject getResult = JObject.Parse(GetJsonString(parameters));
                var jsonContent = new StringContent(getResult.ToString(), Encoding.UTF8, "application/json");
                var response = await ClientHttp.PostAsync(ApiConfig.BaseApiAddress + paramUrl, jsonContent);
                var content = await response.Content.ReadAsStringAsync();
                int nID;
                int nId = int.TryParse(content, out nID) ? nID : 0;
                result.Add(nId, content);
                return result;
         //   }
        /*    catch (Exception)
            {
                Dictionary<int, string> result = new Dictionary<int, string>();
                result.Add(0, ApiConfig.ErrorUnknown);
                return result;
            }*/
        }

        /// <summary>
        /// Post only item class object
        /// </summary>
        /// <param name="param">Item created (without id)</param>
        /// <param name="paramUrl">Part of the URL of the API that need to be called</param>
        /// <typeparam name="T">Type of the item created</typeparam>
        /// <returns>the id of the object created</returns>
        public async Task<int> PostAsync<T>(T param, string paramUrl)
        {
            try
            {
                var jsonstring = JsonConvert.SerializeObject(param);
                var jsonContent = new StringContent(jsonstring, Encoding.UTF8, "application/json");
                var response = await ClientHttp.PostAsync(ApiConfig.BaseApiAddress + paramUrl, jsonContent);
                var content = await response.Content.ReadAsStringAsync();
                int nID;
                return int.TryParse(content, out nID) ? nID : 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Get One Item whith a list of parameters in the request
        /// This method is generic and work with values that have toString() method
        /// </summary>
        /// <param name="paramUrl"></param>
        /// <param name="parameters">Dictionnary with Key = param name  and Value = param value</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<T> GetOneAsync<T>(string paramUrl, Dictionary<string, object> parameters)
        {
            try
            {
                JObject getResult = JObject.Parse(GetJsonString(parameters));
                var jsonContent = new StringContent(getResult.ToString(), Encoding.UTF8, "application/json");
                var response = await ClientHttp.PostAsync(ApiConfig.BaseApiAddress + paramUrl, jsonContent);
                var json = await response.Content.ReadAsStringAsync();
                T res = JsonConvert.DeserializeObject<T>(json);
                return res;
            }
            catch (Exception)
            {
                return default;
            }
        }

        /// <summary>
        /// Get a Jsonstring for all the parameters with their name and value
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string GetJsonString(Dictionary<string, object> parameters)
        {
            string jsonString = @"{";
            int i = 0;
            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                i++;
                jsonString += @"'" + parameter.Key + "':'" + parameter.Value + "'";
                if (i != parameters.Count)
                    jsonString += @",";
            }

            jsonString += @"}";
            return jsonString;
        }
    }
}