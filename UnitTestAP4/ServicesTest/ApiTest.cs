using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using AP4test.Config;
using AP4test.Models;
using AP4test.Services;
using AP4test.ViewModels.EnchereSample.Config;
using Newtonsoft.Json;
using NUnit.Framework;

namespace UnitTestAP4.ServicesTest;

public class ActualPrice
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("prixenchere")]
    public decimal Prixenchere { get; set; }

    public ActualPrice(int id,decimal prixenchere)
    {
        Id = id;
        Prixenchere = prixenchere;
    }
    
    
}

public class Tests
{
    #region Parser
    [Test]
    public void GetJsonString()
    {
        #region OnePair
        //Dictionnary with only one keyvalue pair
        Dictionary<string, object> onePair = new Dictionary<string, object>();
        onePair.Add(ApiConfig.GetEnchere_type, 1);
        string exceptedOnePair = @"{"+
                                 @"'"+ApiConfig.GetEnchere_type+"':'"+1+@"'"+
                                 @"}";

        string parsedOnePair = Api.GetJsonString(onePair);
        
        Assert.AreEqual(exceptedOnePair,parsedOnePair);
        

        #endregion

        #region Nothing

        //Dictionnary with nothing in it
        Dictionary<string, object> nothing = new Dictionary<string, object>();
        string exceptedNothing = @"{"+@"}";

        string parsedNothing = Api.GetJsonString(nothing);
        
        Assert.AreEqual(exceptedNothing,parsedNothing);

        #endregion

        #region MultiplePair

        //Dictionnary with more than one keyvalue pair
        Dictionary<string, object> multiplePair = new Dictionary<string, object>();
        multiplePair.Add(ApiConfig.PostEncherir_IdUser,1);
        multiplePair.Add(ApiConfig.PostEncherir_IdEnchere, 13);
        multiplePair.Add(ApiConfig.PostEncherir_Coefficient, 1.10);
        multiplePair.Add(ApiConfig.PostEncherir_PrixEnchere, 300);
        string exceptedMultiplePair = @"{"+
                                      @"'"+ApiConfig.PostEncherir_IdUser+"':'"+1+@"'"+@","+
                                      @"'"+ApiConfig.PostEncherir_IdEnchere+"':'"+13+@"'"+@","+
                                      @"'"+ApiConfig.PostEncherir_Coefficient+"':'"+1.10+@"'"+@","+
                                      @"'"+ApiConfig.PostEncherir_PrixEnchere+"':'"+300+@"'"+
                                      @"}";
        
        string parsedMultiplePair = Api.GetJsonString(multiplePair);
        
        Assert.AreEqual(exceptedMultiplePair,parsedMultiplePair);

        #endregion
    }
    #endregion

    [Test]
    public async Task GetOneAsync()
    {
        Api apiServices = new Api();
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add(ApiConfig.GetUserByMailAndPass_Mail,"milos@gmail.com");
        param.Add(ApiConfig.GetUserByMailAndPass_Pass,"toto");

        User result = await apiServices.GetOneAsync<User>(ApiConfig.GetUserByMailAndPass, param);
        
        Assert.AreEqual(1,result.IdApi);
        Assert.AreEqual("milos@gmail.com",result.Email);
        Assert.AreEqual("https://static.wikia.nocookie.net/camp-halfblood-fanon/images/c/ca/Unknown.jpeg/revision/latest/top-crop/width/360/height/450?cb=20200614091044",result.Photo);
        Assert.AreEqual("Ricardo",result.Pseudo);
        Assert.AreEqual("toto",result.Password);


        
    }
    [Test]
    public async Task GetAllAsync()
    {
        Api apiServices = new Api();
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add(ApiConfig.GetEnchere_type, 2);
        
        var result = await apiServices.GetAllAsync(ApiConfig.GetEnchere, Enchere.CollEnchere, param);
        string resultjson = JsonConvert.SerializeObject(result[0]);
        
        Enchere excepted = new Enchere(3,
            new DateTime(2022, 02, 23, 13, 57, 31),
            new DateTime(2022, 05, 12, 11, 50, 49),
            300,
            true,
            new TypeEnchere("2","inversevrai"),
            new Produit(13,
                "Figurine Naruto Shippuden - Hachibi & Killer Bee - Jinchuuriki Killer Bee Ver.",
                "https://www.nautiljon.com/images/goodies/00/22/naruto_shippuden_-_hachibi_killer_bee_-_jinchuuriki_killer_bee_ver_-_hqs_tsume_4022.jpg",
                340)
        );
        excepted.Magasin = new Magasin("1", "manga store", "rue des cordiers","Lannion","22300","0650419878",
            48.7303744,-3.4491938);
        excepted.PrixDepart = 584;
        string exceptedjson = JsonConvert.SerializeObject(excepted);
        Assert.AreEqual(exceptedjson,resultjson);
    }
    [Test]
    public void PostAsyncObject()
    {
        Api apiServices = new Api();
        Random aleatoire = new Random();
        User user = new User(
            "PseudoUnitTestAB"+aleatoire.Next(),
            "PhotoUnitTestAB"+aleatoire.Next(),
            "PassUnitTestAB"+aleatoire.Next(),
            "MailUnitTestAB"+aleatoire.Next());
        
       Task<int> result =  apiServices.PostAsync(user, ApiConfig.PostUser);
       
       Assert.AreNotEqual(0,result);
    }
    [Test]
    public async Task PostAsyncDictionnary()
    {
        Api apiServices = new Api();

        #region CurrentPrice

        //Get Current price
        int idEnchereClassique = 13;
        int idEnchereInverser = 3;
        
        Dictionary<string, object> paramInverser = new Dictionary<string, object>();
        paramInverser.Add(ApiConfig.GetActualPrice_ID, idEnchereInverser);
        ActualPrice resultInverser = await apiServices.GetOneAsync<ActualPrice>(ApiConfig.GetActualPrice,paramInverser );
        
        Dictionary<string, object> paramClassique = new Dictionary<string, object>();
        paramClassique.Add(ApiConfig.GetActualPrice_ID, idEnchereClassique);
        ActualPrice resultClassique = await apiServices.GetOneAsync<ActualPrice>(ApiConfig.GetActualPrice, paramClassique);

        #endregion

        #region OfferPass

        //Offer pass
        Dictionary<string, object> offerPass = new Dictionary<string, object>();
        offerPass.Add(ApiConfig.PostEncherir_IdUser, 1);
        offerPass.Add(ApiConfig.PostEncherir_IdEnchere, idEnchereClassique);
        offerPass.Add(ApiConfig.PostEncherir_Coefficient, (EnchereSampleConfig.PercentClassique+1).ToString(CultureInfo.InvariantCulture));
        offerPass.Add(ApiConfig.PostEncherir_PrixEnchere, (resultClassique.Prixenchere*(EnchereSampleConfig.PercentClassique+1.01m)).ToString(CultureInfo.InvariantCulture));
        Dictionary<int, string> resultOfferPass= await  apiServices.PostAsync(ApiConfig.PostEncherir, offerPass);
        Assert.IsTrue(resultOfferPass.ContainsKey(0));

        #endregion

        #region OfferTooLow

        //Offer Price Too Low
        Dictionary<string, object> offerTooLow = new Dictionary<string, object>();
        offerTooLow.Add(ApiConfig.PostEncherir_IdUser, 1);
        offerTooLow.Add(ApiConfig.PostEncherir_IdEnchere, idEnchereClassique);
        offerTooLow.Add(ApiConfig.PostEncherir_Coefficient, EnchereSampleConfig.PercentClassique+1);
        offerTooLow.Add(ApiConfig.PostEncherir_PrixEnchere, resultClassique.Prixenchere);
        Dictionary<int, string> resultOfferTooLow= await  apiServices.PostAsync(ApiConfig.PostEncherir, offerTooLow);
        Assert.AreEqual("PRICE_TOO_LOW",resultOfferTooLow[0]);

        #endregion


        #region OfferTooHigh

        //Offer Price Too High
        Dictionary<string, object> offerTooHigh = new Dictionary<string, object>();
        offerTooHigh.Add(ApiConfig.PostEncherir_IdUser, 1);
        offerTooHigh.Add(ApiConfig.PostEncherir_IdEnchere, idEnchereInverser);
        offerTooHigh.Add(ApiConfig.PostEncherir_Coefficient, EnchereSampleConfig.PercentInverser);
        offerTooHigh.Add(ApiConfig.PostEncherir_PrixEnchere, resultInverser.Prixenchere);
        Dictionary<int, string> resultOfferTooHigh= await apiServices.PostAsync(ApiConfig.PostEncherir, offerTooHigh);
        Assert.AreEqual("PRICE_TOO_HIGH",resultOfferTooHigh[0]);

        #endregion
    }

}