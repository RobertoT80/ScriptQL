using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptQL;

namespace UtilsTest
{
    [TestClass]
    public class TestUtils
    {

        Random _random = new Random();

        [TestMethod]
        public void Test_IsStringValid()
        {
            List<string> myList;
            for (var i = 1; i < 128; i++)
            {
                myList = RandomFactory.GetRandomListOfString(64, i);
                foreach (var s in myList)
                {
                    var res = Utils.IsStringValid(s);
                    Assert.AreEqual(res, true);
                }
            }

            for (var i = 1; i < 128; i++)
            {
                myList = RandomFactory.GetRandomListOfInt(64, i);
                foreach (var s in myList)
                {
                    var res = Utils.IsStringValid(s);
                    Assert.AreEqual(res, true);
                }
            }

            for (var i = 1; i < 128; i++)
            {
                myList = RandomFactory.GetRandomListOfSpecialString(64, i);
                foreach (var s in myList)
                {
                    var res = Utils.IsStringValid(s);
                    Assert.AreEqual(res, false);
                }
            }
            
        }
    }
}
