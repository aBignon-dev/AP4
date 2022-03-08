using System.Collections.Generic;

namespace AP4test.Models
{
    class User
    {
        #region Attributs

        public static List<User> CollClasse = new List<User>();

        #endregion

        #region Constructeurs

        public User(string email, string password, string pseudo, string photo)
        {
            User.CollClasse.Add(this);
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
