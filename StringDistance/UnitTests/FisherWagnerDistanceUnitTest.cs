using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicSugar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringDistances
{
    /// <summary>
    /// See https://en.wikipedia.org/wiki/Wagner%E2%80%93Fischer_algorithm
    /// </summary>
    [TestClass]
    public class FisherWagnerDistanceUnitTest
    {
        [TestMethod]
        public void FisherWagner_ABV_FV()
        {

var expectedMatrix = @"         F   V  
    000 001 002 
 A  001 001 002 
 B  002 002 002 
 V  003 003 002 
";
            var result = new FisherWagner().Compute("ABV", "FV");
            Assert.AreEqual(2, result.Value);
            Assert.AreEqual(expectedMatrix, result.MatrixAsString);
        }

        [TestMethod]
        public void FisherWagner_Sunday_Saturday()
        {

var expectedMatrix = @"         S   a   t   u   r   d   a   y  
    000 001 002 003 004 005 006 007 008 
 S  001 000 001 002 003 004 005 006 007 
 u  002 001 001 002 002 003 004 005 006 
 n  003 002 002 002 003 003 004 005 006 
 d  004 003 003 003 003 004 003 004 005 
 a  005 004 003 004 004 004 004 003 004 
 y  006 005 004 004 005 005 005 004 003 
";
            var result = new FisherWagner().Compute("Sunday", "Saturday");
            Assert.AreEqual(3, result.Value);
            Assert.AreEqual(expectedMatrix, result.MatrixAsString);
        }

        [TestMethod]
        public void FisherWagner_sitting_kitten()
        {
            FisherWagner.FisherWagnerResult result;
            var expectedMatrix = @"         k   i   t   t   e   n  
    000 001 002 003 004 005 006 
 s  001 001 002 003 004 005 006 
 i  002 002 001 002 003 004 005 
 t  003 003 002 001 002 003 004 
 t  004 004 003 002 001 002 003 
 i  005 005 004 003 002 002 003 
 n  006 006 005 004 003 003 002 
 g  007 007 006 005 004 004 003 
";
            result = new FisherWagner().Compute("sitting", "kitten");
            Assert.AreEqual(3, result.Value);
            Assert.AreEqual(expectedMatrix, result.MatrixAsString);
        }
    }
}
