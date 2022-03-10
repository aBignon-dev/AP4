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
        GetGagnant = "getGagnant",
        GetEnchereParticipes = "getEncheresParticipes",
        GetEncheresEnCours = "getEncheresEnCours",
        #endregion
        #region Encherir
        GetActualPrice = "getActualprice",
        GetLastSixOffer = "getLastSixOffer",
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
