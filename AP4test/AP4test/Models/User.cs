using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SQLite;

namespace AP4test.Models
{
    [Table("User")]
    public class User
    {
        #region Attributs

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur d'un User avec la BDD 
        /// </summary>
        /// <param name="pseudo"></param>
        /// <param name="photo"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        public User(string pseudo, string photo, string password, string email)
        {
            Email = email;
            Password = password;
            Pseudo = pseudo;
            Photo = photo;
        }

        /// <summary>
        /// Constructeur d'un User avec la BDD 
        /// </summary>
        /// <param name="pseudo"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        public User(string pseudo, string password, string email)
        {
            Email = email;
            Password = password;
            Pseudo = pseudo;
        }

        public User()
        {
        }

        #endregion

        #region Getters/Setters

        [PrimaryKey, AutoIncrement] public int ID { get; set; }

        [JsonProperty("id")] public int IdApi { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Pseudo { get; set; }

        public string Photo { get; set; }

        #endregion

        #region Methodes
        /// <summary>
        /// Supprime tout les User de la base
        /// </summary>
        public static async Task DeleteAllSqlite()
        {
            await App.Database.DeleteAllAsync<User>();
        }
        /// <summary>
        /// Ajoute le User a la BDD
        /// </summary>
        /// <param name="param">User a ajouter</param>
        public static async Task AjoutItemSqlite(User param)
        {
            await App.Database.SaveItemAsync(param);
        }
        /// <summary>
        /// Récupere tout les User dans la BDD
        /// </summary>
        /// <returns>Collection de User</returns>
        public static Task<ObservableCollection<User>> GetAllItemsSqlite()
        {
            return Task.FromResult(App.Database.GetItemsAsync<User>());
        }

        #endregion
    }
}