using AP4test.Util;
using NUnit.Framework;

namespace UnitTestAP4.UtilTest;

public partial class Tests
{
    [Test]
    public void PriceFormatValidate()
    {
        #region Correct Format

        #region Less than a Thousand

        string lessThousand = "100";
        int lessThousandExcepted = 100;
        
        int lessThousandResult = ValidateUtil.PriceFormatValidate(lessThousand);

        Assert.AreEqual(lessThousandExcepted,lessThousandResult);
        #endregion

        #region Thousand
        string thousand = "1k";
        int thousandExcepted = PrixUtil.thousand;
        
        int thousandResult = ValidateUtil.PriceFormatValidate(thousand);

        Assert.AreEqual(thousandExcepted,thousandResult);
        #endregion

        #region Million
        string million = "1m";
        int millionExcepted = PrixUtil.million;
        
        int millionResult = ValidateUtil.PriceFormatValidate(million);

        Assert.AreEqual(millionExcepted,millionResult);
        #endregion

        #region Billion
        string billion = "1B";
        int billionExcepted = PrixUtil.billion;
        
        int billionResult = ValidateUtil.PriceFormatValidate(billion);

        Assert.AreEqual(billionExcepted,billionResult);
        #endregion

        #endregion

        #region Incorrect Format

        #region Only string
        string onlyString = "onlyString";
        int onlyStringExcepted = -1;
        
        int onlyStringResult = ValidateUtil.PriceFormatValidate(onlyString);

        Assert.AreEqual(onlyStringExcepted,onlyStringResult);
        #endregion

        #region Starting with string and ending with number
        string stringNumber = "k20";
        int stringNumberExcepted = -1;
        
        int stringNumberResult = ValidateUtil.PriceFormatValidate(stringNumber);

        Assert.AreEqual(stringNumberExcepted,stringNumberResult);
        #endregion

        #region Ending incorrect with string at end
        string endingStringIncorrect = "5mCacahuete";
        int endingStringIncorrectExcepted = -1;
        
        int endingStringIncorrectResult = ValidateUtil.PriceFormatValidate(endingStringIncorrect);

        Assert.AreEqual(endingStringIncorrectExcepted,endingStringIncorrectResult);
        #endregion

        #region Ending incorrect with number at end
        string endingIntIncorrect = "5m480";
        int endingIntIncorrectExcepted = -1;
        
        int endingIntIncorrectResult = ValidateUtil.PriceFormatValidate(endingIntIncorrect);

        Assert.AreEqual(endingIntIncorrectExcepted,endingIntIncorrectResult);
        #endregion

        #endregion
    }
    
}