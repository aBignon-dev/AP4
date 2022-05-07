using AP4test.Util;
using NUnit.Framework;

namespace UnitTestAP4.UtilTest;

public partial class Tests
{
    [Test]
    public void FormatInPut()
    {
        //Thousand convert
        Assert.AreEqual(PrixUtil.thousand*10,PrixUtil.FormatInPut(10,'k'));
        
        //Million convert
        Assert.AreEqual(PrixUtil.million*5,PrixUtil.FormatInPut(5,'m'));
       
        //Billion convert
        Assert.AreEqual(PrixUtil.billion,PrixUtil.FormatInPut(1,'B'));
        
        //Incorrect format result
        Assert.AreEqual(-1,PrixUtil.FormatInPut(10,'p'));
    }
    [Test]
    public void FormatOuput()
    {
        #region Thousand
        string thousandExcepted = "1k";
        
        string thousandResult = PrixUtil.FormatOutput(PrixUtil.thousand);
        
        Assert.AreEqual(thousandExcepted,thousandResult);
        #endregion
        
        #region Million

        string millionExcepted = "1m";

        string millionResult = PrixUtil.FormatOutput(PrixUtil.million);
       
        Assert.AreEqual(millionExcepted,millionResult);
        #endregion

        #region Billion
        string billionExcepted = "1B";

        string billionResult = PrixUtil.FormatOutput(PrixUtil.billion);
       
        Assert.AreEqual(billionExcepted,billionResult);
        #endregion

        #region Less than a thousand
        string excepted = "100";

        string result = PrixUtil.FormatOutput(100);
       
        Assert.AreEqual(excepted,result);
        #endregion
    }
}