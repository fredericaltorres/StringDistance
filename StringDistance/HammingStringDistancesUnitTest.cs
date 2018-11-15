using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicSugar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringDistance
{

    [TestClass]
    public class HammingStringDistancesUnitTest
    {
        List<string> threeLettersWordDic = new List<string>() {
            "cat","cut","cot","cog","dog","foo","coy"
        };

        [TestMethod]
        public void GetHammingDistance()
        {
            Assert.AreEqual(3, HammingStringDistances.GetHammingDistance("karolin", "kathrin"));
            Assert.AreEqual(3, HammingStringDistances.GetHammingDistance("karolin", "kerstin"));
            Assert.AreEqual(2, HammingStringDistances.GetHammingDistance("1011101", "1001001"));
            Assert.AreEqual(3, HammingStringDistances.GetHammingDistance("2173896", "2233796"));
        }

        [TestMethod]
        public void GetListOfWordsWithHammingDistanceOf()
        {
            var result = HammingStringDistances.GetListOfWordsWithHammingDistanceOf(threeLettersWordDic, "pat");
            Assert.AreEqual(1, result.Count);
            CollectionAssert.AreEqual(DS.List("cat"), result);

            result = HammingStringDistances.GetListOfWordsWithHammingDistanceOf(threeLettersWordDic, "coo");
            Assert.AreEqual(4, result.Count);
            CollectionAssert.AreEqual(result, result);
        }

        [TestMethod]
        public void ShortestPathBetweenTwoGivenWordsOfSameLengths()
        {
            var execution = new StringBuilder();
            HammingStringDistances.ShortestPathBetweenTwoGivenWordsOfSameLengths(threeLettersWordDic, "cat", "dog", 0, execution);
var expected = @"cat -> cut
cut -> cot
cot -> cog
cog -> dog Rec:3 Done
cog -> coy
cot -> coy
coy -> cog
cog -> dog Rec:4 Done
cat -> cot
cot -> cut
cot -> cog
cog -> dog Rec:2 Done
cog -> coy
cot -> coy
coy -> cog
cog -> dog Rec:3 Done
";
            Assert.AreEqual(expected, execution.ToString());
        }
    }
}
