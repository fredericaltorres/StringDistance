using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicSugar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringDistances
{
    [TestClass]
    public class ComputeASCIIDeletionDistanceUnitTest
    {
        [TestMethod]
        public void ComputeDistance_SimpleCases()
        {
            Assert.AreEqual(197, new ASCIIDeletionDistance().Compute("cat", "bat").Value);
            Assert.AreEqual(294, new ASCIIDeletionDistance().Compute("cata", "bat").Value);
            Assert.AreEqual(319, new ASCIIDeletionDistance().Compute("cat", "batz").Value);
            Assert.AreEqual( 99, new ASCIIDeletionDistance().Compute("at", "cat").Value);
            Assert.AreEqual(559, new ASCIIDeletionDistance().Compute("thought", "slough").Value);
            Assert.AreEqual(298, new ASCIIDeletionDistance().Compute("bread", "gred").Value);
        }

        [TestMethod]
        public void ComputeDistance_MultipleRepeatOfSameLetter_InStr1()
        {
            var result = new ASCIIDeletionDistance().Compute("cattt", "bat");

var expectedHistory = @"in str1 at 0 char 'c'
in str2 at 0 char 'b'
in str1 at -1 char 't'
in str1 at -1 char 't'
";
            Assert.AreEqual(expectedHistory, result.History);
            Assert.AreEqual(429, result.Value);
        }

        [TestMethod]
        public void ComputeDistance_MultipleRepeatOfSameLetter_InStr2()
        {
            var result = new ASCIIDeletionDistance().Compute("cat", "batzz");

var expectedHistory = @"in str1 at 0 char 'c'
in str2 at 0 char 'b'
in str2 at 3 char 'z'
in str2 at 4 char 'z'
";

            Assert.AreEqual(expectedHistory, result.History);
            Assert.AreEqual(441, result.Value);
        }
        
    }
}
