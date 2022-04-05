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