using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicSugar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringDistance
{
    /*
     
The deletion distance between two strings is the minimum sum of ASCII values of characters 
that you need to delete in the two strings in order to have the same string. 

The deletion distance between cat and at is 99, because you can just delete the first 
character of cat and the ASCII value of 'c' is 99. 

The deletion distance between cat and bat is 98 + 99, because you need to delete the first 
character of both words. 

Of course, the deletion distance between two strings can't be greater than the sum of their 
total ASCII values, because you can always just delete both of the strings entirely. 

Implement an efficient function to find the deletion distance between two strings.

You can refer to the Wikipedia article on the algorithm for edit distance if you want to. 
The algorithm there is not quite the same as the algorithm required here, but it's similar.         

Wagner–Fischer algorithm: 
    https://en.wikipedia.org/wiki/Wagner%E2%80%93Fischer_algorithm
    https://www.programcreek.com/2013/12/edit-distance-in-java/
    https://www.biditacharya.com/expository/a3d/2017/09/15/a3d-word-distance.html

    https://www.geeksforgeeks.org/check-if-two-given-strings-are-at-edit-distance-one/
         
https://repl.it/repls/IcyTragicSigns

    */
    public class ASCIIDeletionDistance
    {
        List<char> deletions = new List<char>();
        Dictionary<char, int> str1Letters = new Dictionary<char, int>();

        public  int ComputeDistanceNotDynamicProgramming(string str1, string str2)
        {
            UpdateDeletionsAndLetterDictionaryPass1(str1, str2);
            UpdateDeletionsAndLetterDictionaryPass2(str2, str1);

            return this.GetDeletionsCount();
        }

        private int GetDeletionsCount()
        {
            var total = 0; // Just count the number of deletions using the ascii value
            deletions.ForEach(c =>
            {
                total += (int)c;
            });
            return total;
        }

        /// <summary>
        /// Analyse the str1 based on str2, foreach char in str1
        /// - if letter is not in str2, them mark the letter for deletion
        /// - create a dictionary to count each letter in str1
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        private void UpdateDeletionsAndLetterDictionaryPass1(string str1, string str2)
        {
            for (var i = 0; i < str1.Length; i++)
            {
                var letter = str1[i];

                if (!str2.Contains(letter)) // This letter is not in str2 therefore must be deleted
                    deletions.Add(letter);

                if (str1Letters.ContainsKey(letter)) // Just count the number of letter
                    str1Letters[letter] += 1;
                else
                    str1Letters[letter] = 1;                    
            }
        }
        /// <summary>
        /// Analyse str2 based on str1, foreach char in str2
        /// - if the letter has count > 0 then decrease it
        /// - if the letter has count of 0 then mark the letter for deletions
        /// </summary>
        /// <param name="str2"></param>
        /// <param name="str1"></param>
        private void UpdateDeletionsAndLetterDictionaryPass2(string str2, string str1)
        {
            for (var i = 0; i < str2.Length; i++)
            {
                var letter = str2[i];
                // Count the number of letter in both string
                if (str1Letters.ContainsKey(letter) && str1Letters[letter] > 0) 
                    str1Letters[letter] -= 1;
                else
                    deletions.Add(letter);
            }

            // Check for letter that where twice in str1 but once in str2
            foreach(var e in str1Letters)
            {
                if(e.Value > 0 && !this.deletions.Contains(e.Key)) {
                    deletions.Add(e.Key);
                }
            }
        }
    }
}
