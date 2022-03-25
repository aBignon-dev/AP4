using System;
using System.Collections.Generic;
using System.Text;

namespace AP4test.Config
{
    public static class ApiConfig
    {
        public static string
            BaseApiAddress = "http://172.17.0.61:8000/api/",
        #region Enchere
        GetEnchere = "getEnchere", 
        GetEnchere_type = "IdTypeEnchere",
        GetGagnant = "getGagnant",
        GetEnchereParticipes = "getEncheresParticipes",
        GetEncheresEnCours = "getEncheresEnCours",
        #endregion
        #region Encherir
        PostEncherir ="postEncherir", 
        PostEncherir_IdUser ="IdUser",
        PostEncherir_IdEnchere ="IdEnchere",
        PostEncherir_Coefficient ="Coefficient",
        PostEncherir_PrixEnchere ="PrixEnchere",
        GetActualPrice = "getActualprice",
        GetLastSixOffer = "getLastSixOffer", 
        GetLastSixOffer_EnchereID = "Id",
        #endregion
        #region Magasin
        #endregion
        #region Produit
        GetProduit = "getProduit",
        PostProduit = "postProduit",
        #endregion
        #region Users
        GetUserByMailAndPass = "getUserByMailAndPass",
        PostUser = "postUser"

        #endregion
            ;
        
    }
}
