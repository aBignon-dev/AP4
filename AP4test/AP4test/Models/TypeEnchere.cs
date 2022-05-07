using System.Collections.Generic;

namespace AP4test.Models
{
    public class TypeEnchere
    {
        #region Attributs

        public static readonly List<TypeEnchere> CollClasse = new List<TypeEnchere>();

        public string Id { get; set; }
        public string Nom { get; set; }

        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur de la classe TypeEnchere
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        public TypeEnchere(string id, string nom)
        {
            Id = id;
            Nom = nom;
            CollClasse.Add(this);
        }

        #endregion

        #region Getters/Setters

        #endregion

        #region Methodes

        #endregion
    }
}