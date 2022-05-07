using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AP4test.Util;
using Newtonsoft.Json;

namespace AP4test.Models
{
    public class Enchere
    {
        #region Attributs

        public static readonly List<Enchere> CollEnchere = new List<Enchere>();

        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur de la classe Enchere
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateDebut"></param>
        /// <param name="dateFin"></param>
        /// <param name="prixreserve"></param>
        /// <param name="visibilite"></param>
        /// <param name="typeEnchere"></param>
        /// <param name="produit"></param>
        public Enchere(int id, DateTime dateDebut, DateTime dateFin, float prixreserve, bool visibilite,
            TypeEnchere typeEnchere, Produit produit)
        {
            Id = id;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Visibilite = visibilite;
            Prixreserve = prixreserve;
            TypeEnchere = typeEnchere;
            Produit = produit;
            CollEnchere.Add(this);
        }

        #endregion

        #region Getters/Setters

        public int Id { get; set; }
        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }

        public bool Visibilite { get; set; }
        public float Prixreserve { get; set; }
        
        /// <summary>
        /// Accesseur du prix reserve permettant l'affichage spécialisé suivant l'attribut Visibilité
        /// </summary>
        public string PrixreserveRead
        {
            get
            {
                if (!Visibilite)
                    return "Secret";
                return PrixUtil.FormatOutput(Prixreserve) + " €";
            }
            set { PrixreserveRead = value; }
        }

        [JsonProperty("lemagasin")] public Magasin Magasin { get; set; }

        [JsonProperty("letypeenchere")] public TypeEnchere TypeEnchere { get; set; }

        [JsonProperty("leproduit")] public Produit Produit { get; set; }

        /// <summary>
        /// Accesseur du nom de produit permettant l'affichage spécialisé suivant le type d'enchère
        /// </summary>
        public string NomRead
        {
            get
            {
                if (TypeEnchere.Id == "3")
                    return "Secret";
                return Produit.Nom;
            }
            set { NomRead = value; }
        }
        /// <summary>
        /// Accesseur du nom de produit permettant l'affichage spécialisé suivant le type d'enchère
        /// </summary>
        public string PhotoRead
        {
            get
            {
                if (TypeEnchere.Id == "3")
                    return "https://fr.shopping.rakuten.com/photo/boite-mystere-1229904330_ML.jpg";
                return Produit.Photo;
            }
            set { PhotoRead = value; }
        }

        [JsonProperty("prixdepart")] public double PrixDepart { get; set; }

        [JsonProperty("tableauFlash")] public string TableauFlash { get; set; }

        #endregion

        #region Methodes
        /// <summary>
        /// Récupere l'enchère rechercher par rappport a l'id envoyer en paramètre
        /// </summary>
        /// <param name="IdEnchere">l'id de l'enchère rechercher</param>
        /// <returns>L'enchère  correspondante</returns>
        public static Enchere GetEnchereSelected(string IdEnchere)
        {
            foreach (var enchere in CollEnchere)
                if (enchere.Id.ToString() == IdEnchere)
                    return enchere;
            return null;
        }

        #endregion
    }
}