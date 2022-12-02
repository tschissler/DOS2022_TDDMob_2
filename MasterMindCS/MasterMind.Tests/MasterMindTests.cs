using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterMind.App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterMind.Tests;
[TestClass]
public class MasterMindTests
{
    [TestMethod]
    public void All_CorrectReturnsPPPP()
    {
        validate("ABCD", "ABCD", "PPPP");        
    }

    [TestMethod]
    public void GetGuessFeedback_NothingCorrectReturnsEmptyString()
    {
        validate("ABCD", "EFGH", "");        
    }

    [TestMethod]
    public void GetGuessFeedback_OneCorrectPositionReturnsP()
    {
        validate("ABCD", "AEFG", "P");        
    }

    [TestMethod]
    public void GetGuessFeedback_TwoCorrectPositionReturnsPP()
    {
        validate("ABCD", "ABFG", "PP");        
    }

    [TestMethod]
    public void GetGuessFeedback_OneCorrectOnPosition2_ReturnsP()
    {
        validate("ABCD", "EBFG", "P");        
    }

    [TestMethod]
    public void GetGuessFeedback_OneColorCorrect_ReturnsC()
    {
        validate("ABCD", "EAFG", "C");        
    }

    [TestMethod]
    public void GetGuessFeedback_TwoColorsWrongPosition_ReturnsCC()
    {
        validate("ABCD", "BAAG", "CC");        
    }

    [TestMethod]
    public void GetGuessFeedback_TwoColorsWrongPositionMultiple_ReturnsCC()
    {
        validate("BAAG", "ABCD", "CC");        
    }

    [TestMethod]
    public void GetGuessFeedback_PPCC_1()
    {
        validate("ABCD", "ABDC", "PPCC");
    }

    [TestMethod]
    public void GetGuessFeedback_PPCC_2()
    {
        validate("ABCD", "ACBD", "PPCC");
    }

    [TestMethod]
    public void GetGuessFeedback_PPCC_3()
    {
        validate("AABB", "CCAB", "PC");
    }

    [TestMethod]
    public void GetGuessFeedback_PPCC_31()
    {
        validate("CCAB", "AABB", "PC");
    }

    [TestMethod]
    public void GetGuessFeedback_PPCC_4()
    {
        validate("ABBB", "ACCA", "P");
    }




    private static void validate(string code, string guess, string expected)
    {
        var result = MasterMindLogic.GetGuessFeedback(code, guess);

        Assert.AreEqual(expected, result);

    }

}
