using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace AP4test.Models
{
    public class Encherir
    {
        #region Attributs
        public static List<Encherir> CollOffer = new List<Encherir>();

        #endregion

        #region Constructeurs

        public Encherir(double prixenchere, string pseudoUser)
        {
            PrixEnchere = prixenchere;
            PseudoUser = pseudoUser;
            CollOffer.Add(this);
        }
        #endregion

        #region Getters/Setters
        [JsonProperty("prixenchere")]
        public double PrixEnchere { get; set; }
        
        [JsonProperty("pseudo")]
        public string PseudoUser { get; set; }
        
        public string OfferRead
        {
            get
            {
                if (PseudoUser == "Aucune offre")
                    return PrixEnchereRead;
                return  PseudoUser+ " :"+PrixEnchereRead;
            }
            set { OfferRead = value; }
        }

        public string PrixEnchereRead
        {
            get
            {
                return  PrixEnchere +" €";
            }
            set { PrixEnchereRead = value; }
        }
        

        #endregion

        #region Methodes

        #endregion
    }
}