using System;
using System.Collections.Generic;
using System.Text;

namespace AP4test.Config
{
    public class ApiConfig
    {
        public static string
            BaseApiAddress = "http://172.17.0.61:8000/api/",
        #region Enchere
            get_encheres = "getEncheres",
            get_encheres_by_id = "getEncheres/%idEnchere%",
            getGagnant = "getGagnant/%idEnchere%",
            getEncheresParticipes = "getEncheresParticipes/%idUser%",
            getEncheresEnCours = "getEncheresEnCours",
        #endregion
        #region Magasin
        #endregion
        #region Produit
        get_produits = "getProduits",
        #endregion
        #region Users
        get_users = "getUser"
        #endregion
            ;
    }
}
