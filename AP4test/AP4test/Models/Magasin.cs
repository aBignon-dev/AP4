using System.Collections.Generic;

namespace AP4test.Models
{
    public class Magasin
    {
        #region Attributs

        public static readonly List<Magasin> CollClasse = new List<Magasin>();
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Codepostal { get; set; }
        public string Portable { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

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