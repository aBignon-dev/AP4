using System.Collections.Generic;
using Newtonsoft.Json;

namespace AP4test.Models
{
    public class User
    {
        #region Attributs
        
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur d'un User avec le PostUser 
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
        #endregion

        #region Getters/Setters
        public string Email { get; set; }
        public string Password { get; set; }
        public string Pseudo { get; set; }
        public string Photo { get; set; }

        #endregion

        #region Methodes

        #endregion
    }
}
