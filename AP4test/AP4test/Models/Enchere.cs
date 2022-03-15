using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace AP4test.Models
{
    public class Enchere
    {
        #region Attributs

        public static readonly List<Enchere> CollEnchere = new List<Enchere>();

        #endregion

        #region Constructeurs

        public Enchere(int id,DateTime dateDebut, DateTime dateFin, float prixreserve,bool visibilite,TypeEnchere typeEnchere, Produit produit)
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


        public string PrixreserveRead
        {
            get
            {
                if(!Visibilite)
                   return "Secret";
                return  Prixreserve.ToString() +" €";
            }
            set
            {
                PrixreserveRead = value;
            } 
        }

        [JsonProperty("letypeenchere")]
        public TypeEnchere TypeEnchere { get; set; }
        
        [JsonProperty("leproduit")]
        public Produit Produit { get; set; }

        public string NomRead
        {
            get
            {
                if (TypeEnchere.Id=="3")
                    return "Secret";
                return Produit.Nom;
            }
            set { NomRead = value; }
        }

        public string PhotoRead
        {
            get
            {
                if (TypeEnchere.Id=="3")
                    return "https://fr.shopping.rakuten.com/photo/boite-mystere-1229904330_ML.jpg";
                return Produit.Photo;
            }
            set { PhotoRead = value; }
        }
        #endregion

        #region Methodes

        #endregion
    }
}