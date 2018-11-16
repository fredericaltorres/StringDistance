using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicSugar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringDistance
{

    [TestClass]
    public class ComputeASCIIDeletionDistanceUnitTest
    {
        [TestMethod]
        public void ComputeDistanceNotDynamicProgrammingSolution1()
        {
            Assert.AreEqual(197, new ASCIIDeletionDistance().ComputeDistanceNotDynamicProgramming("cat", "bat"));
            Assert.AreEqual(294, new ASCIIDeletionDistance().ComputeDistanceNotDynamicProgramming("cata", "bat"));
            Assert.AreEqual(319, new ASCIIDeletionDistance().ComputeDistanceNotDynamicProgramming("cat", "batz"));
            Assert.AreEqual(441, new ASCIIDeletionDistance().ComputeDistanceNotDynamicProgramming("cat", "batzz"));

            Assert.AreEqual(99, new ASCIIDeletionDistance().ComputeDistanceNotDynamicProgramming("at", "cat"));
            Assert.AreEqual(559, new ASCIIDeletionDistance().ComputeDistanceNotDynamicProgramming("thought", "slough"));
            Assert.AreEqual(298, new ASCIIDeletionDistance().ComputeDistanceNotDynamicProgramming("bread", "gred"));
        }
        
         [TestMethod]
        public void FisherWagner()
        {
            Assert.AreEqual(197, new ASCIIDeletionDistance().FisherWagner("ABV", "FV"));
        }
    }
}
