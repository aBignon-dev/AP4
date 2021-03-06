using System.Collections.Generic;

namespace AP4test.Models
{
    public class Produit
    {
        #region Attributs

        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur de la classe Produit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        /// <param name="photo"></param>
        /// <param name="prixreel"></param>
        public Produit(int id, string nom, string photo, float prixreel)
        {
            Id = id;
            Nom = nom;
            Photo = photo;
            Prixreel = prixreel;
        }

        #endregion

        #region Getters/Setters

        public int Id { get; set; }

        public string Nom { get; set; }

        public string Photo { get; set; }

        public float Prixreel { get; set; }

        #endregion

        #region Methodes

        #endregion
    }
}