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
        public void __ComputeDistanceNotDynamicProgramming()
        {
            Assert.AreEqual(197, new ASCIIDeletionDistance().ComputeDistanceNotDynamicProgramming("cat", "bat").Value);
            Assert.AreEqual(294, new ASCIIDeletionDistance().ComputeDistanceNotDynamicProgramming("cata", "bat").Value);
            Assert.AreEqual(319, new ASCIIDeletionDistance().ComputeDistanceNotDynamicProgramming("cat", "batz").Value);
            Assert.AreEqual(441, new ASCIIDeletionDistance().ComputeDistanceNotDynamicProgramming("cat", "batzz").Value);
            Assert.AreEqual(429, new ASCIIDeletionDistance().ComputeDistanceNotDynamicProgramming("cattt", "bat").Value);

            Assert.AreEqual(99, new ASCIIDeletionDistance().ComputeDistanceNotDynamicProgramming("at", "cat").Value);
            Assert.AreEqual(559, new ASCIIDeletionDistance().ComputeDistanceNotDynamicProgramming("thought", "slough").Value);
            Assert.AreEqual(298, new ASCIIDeletionDistance().ComputeDistanceNotDynamicProgramming("bread", "gred").Value);
        }
        
         [TestMethod]
        public void FisherWagner()
        {
            //Assert.AreEqual(197, new FisherWagner().ComputeFisherWagner("ABV", "FV"));
        }
    }
}
