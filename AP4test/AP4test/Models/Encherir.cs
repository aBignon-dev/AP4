using System.Collections.Generic;
using System.Collections.ObjectModel;
using AP4test.Util;
using Newtonsoft.Json;

namespace AP4test.Models
{
    public class Encherir
    {
        #region Attributs

        public static List<Encherir> CollOffer = new List<Encherir>();

        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur de la classe encherir
        /// </summary>
        /// <param name="prixenchere"></param>
        /// <param name="pseudoUser"></param>
        public Encherir(float prixenchere, string pseudoUser)
        {
            PrixEnchere = prixenchere;
            PseudoUser = pseudoUser;
            CollOffer.Add(this);
        }

        #endregion

        #region Getters/Setters

        [JsonProperty("prixenchere")] public float PrixEnchere { get; set; }

        [JsonProperty("pseudo")] public string PseudoUser { get; set; }

        /// <summary>
        /// Accesseur qui fusionne l'attribut pseudo et le prix de l'enchere
        /// </summary>
        public string OfferRead
        {
            get
            {
                if (PseudoUser == "Aucune offre")
                    return PrixEnchereRead;
                return PseudoUser + " :" + PrixEnchereRead;
            }
            set { OfferRead = value; }
        }
        /// <summary>
        /// Accesseur qui transforme le prix de l'enchere en prix formater (50000=50k)
        /// </summary>
        public string PrixEnchereRead
        {
            get { return PrixUtil.FormatOutput(PrixEnchere) + " €"; }
            set { PrixEnchereRead = value; }
        }

        #endregion

        #region Methodes

        #endregion
    }
}