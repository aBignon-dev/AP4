using System;
using System.Collections.Generic;

namespace AP4test.Models
{
    class Enchere
    {
        #region Attributs

        public static readonly List<Enchere> CollClasse = new List<Enchere>();

        #endregion

        #region Constructeurs

        public Enchere(int id, DateTime dateDebut, DateTime dateFin, float prixreserve, int typeEnchereId, int produitId)
        {
            Id = id;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Prixreserve = prixreserve;
            TypeEnchereId = typeEnchereId;
            ProduitId = produitId;
            Enchere.CollClasse.Add(this);

        }



        #endregion

        #region Getters/Setters
        public int Id { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }

        public float Prixreserve { get; set; }

        public int TypeEnchereId { get; set; }

        public int ProduitId { get; set; }

        #endregion

        #region Methodes

        #endregion
    }
}
