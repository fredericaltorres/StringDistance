using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicSugar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringDistance
{

    public class StringDistances
    {
        /// <summary>
        /// https://en.wikipedia.org/wiki/Hamming_distance
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int GetHammingDistance(string source, string target)
        {
            if(source.Length != target.Length)
                throw new Exception("Strings must be equal length");

            var distance = 0;
            for(int i=0; i<source.Length; i++)
                if(source[i] != target[i])
                    distance += 1;
            return distance;
        }

        public static List<string> GetListOfWordsWithHammingDistanceOf(List<string> dic, string word, int distance = 1)
        {
            var l = new List<string>();
            foreach(var dw in dic)
                if(GetHammingDistance(word, dw) == distance)
                    l.Add(dw);
            return l;
        }
        public static List<string> CloneDictionaryWithout(List<string> dic, string word)
        {
            var l = new List<string> ();
            foreach(var w in dic)
                if(w != word)
                    l.Add(w);
            return l;
        }

        public static void ShortestPathBetweenTwoGivenWordsOfSameLengths(List<string> dic, string source, string target, int rec, StringBuilder execution)
        {
            var listOfWordWithHammingDistanceOf1 = GetListOfWordsWithHammingDistanceOf(dic, source);

            foreach(var w in listOfWordWithHammingDistanceOf1)
            {
                if(w == target)
                {
                    execution.AppendFormat("{0} -> {1} Rec:{2} Done", source, target, rec).AppendLine();
                }
                else
                {
                    execution.AppendFormat("{0} -> {1}", source, w).AppendLine();
                    ShortestPathBetweenTwoGivenWordsOfSameLengths(CloneDictionaryWithout(dic, source), w,  target, rec + 1, execution);
                }
            }
        }
    }

    [TestClass]
    public class StringDistancesUnitTest
    {
        [TestMethod]
        public void GetHammingDistance()
        {
            Assert.AreEqual(3, StringDistances.GetHammingDistance("karolin", "kathrin"));
            Assert.AreEqual(3, StringDistances.GetHammingDistance("karolin", "kerstin"));
            Assert.AreEqual(2, StringDistances.GetHammingDistance("1011101", "1001001"));
            Assert.AreEqual(3, StringDistances.GetHammingDistance("2173896", "2233796"));
        }

        List<string> threeLettersWordDic = new List<string>() {
            "cat","cut","cot","cog","dog","foo","coy"
        };

        [TestMethod]
        public void GetListOfWordsWithHammingDistanceOf()
        {
            var result = StringDistances.GetListOfWordsWithHammingDistanceOf(threeLettersWordDic, "pat");
            Assert.AreEqual(1, result.Count);
            CollectionAssert.AreEqual(DS.List("cat"), result);

            result = StringDistances.GetListOfWordsWithHammingDistanceOf(threeLettersWordDic, "coo");
            Assert.AreEqual(4, result.Count);
            CollectionAssert.AreEqual(result, result);
        }

        [TestMethod]
        public void ShortestPathBetweenTwoGivenWordsOfSameLengths()
        {
            var execution = new StringBuilder();
            StringDistances.ShortestPathBetweenTwoGivenWordsOfSameLengths(threeLettersWordDic, "cat", "dog", 0, execution);
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
