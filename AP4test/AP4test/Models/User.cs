using System.Collections.Generic;
using Newtonsoft.Json;

namespace AP4test.Models
{
    public class User
    {
        #region Attributs
        
        #endregion

        #region Constructeurs

        public User(int id,string pseudo, string photo, string password, string email)
        {
            Id = id;
            Email = email;
            Password = password;
            Pseudo = pseudo;
            Photo = photo;
        }

        #endregion

        #region Getters/Setters

        [JsonProperty("id")]
        public int Id{ get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("pseudo")]
        public string Pseudo { get; set; }
        [JsonProperty("photo")]
        public string Photo { get; set; }

        #endregion

        #region Methodes

        #endregion
    }
}
