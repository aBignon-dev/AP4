using System.Collections.Generic;

namespace AP4test.Models
{
    public class Magasin
    {
        #region Attributs

        public static readonly List<Magasin> CollClasse = new List<Magasin>();

        public Magasin(string id, string nom, string adresse, string ville, string codepostal, string portable, double latitude, double longitude)
        {
            Id = id;
            Nom = nom;
            Adresse = adresse;
            Ville = ville;
            Codepostal = codepostal;
            Portable = portable;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Id { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Codepostal { get; set; }
        public string Portable { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        #endregion

        #region Constructeurs

        public Magasin()
        {
        }

        #endregion

        #region Getters/Setters

        #endregion

        #region Methodes

        #endregion
    }
}