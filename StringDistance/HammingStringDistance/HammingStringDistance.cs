using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicSugar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringDistances
{
    public class HammingStringDistance
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
}
