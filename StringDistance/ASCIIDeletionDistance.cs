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

    public enum DeletionInfoStringName
    {
        str1,
        str2,
        unknown
    };

    public class DeletionInfo
    {
        public DeletionInfoStringName StringName;
        public Char Letter;
        public int Index;

        public DeletionInfo(DeletionInfoStringName stringName, Char letter, int index)
        {
            this.StringName = stringName;
            this.Letter = letter;
            this.Index = index;
        }
        public override string ToString()
        {
            return $"in {this.StringName} at ${this.Index} char ${this.Letter}";
        }
        public int GetAsciiValue()
        {
            return (int)this.Letter;
        }
    }

    public class ASCIIDeletionDistanceResult {
        public int Value;
    };


    /// <summary>
    /// This class is based on the code https://repl.it/repls/IcyTragicSigns
    /// </summary>
    public class ASCIIDeletionDistance
    {
        List<DeletionInfo> _deletions = new List<DeletionInfo>();
        Dictionary<char, int> _str1LettersCountDictionary = new Dictionary<char, int>();

        public ASCIIDeletionDistanceResult ComputeDistanceNotDynamicProgramming(string str1, string str2)
        {
            var r = new ASCIIDeletionDistanceResult();

            UpdateDeletionsAndLetterDictionaryPass1(str1, str2);
            UpdateDeletionsAndLetterDictionaryPass2(str2, str1);
            r.Value = this.GetDeletionsCount();
            return r;
        }

        private int GetDeletionsCount()
        {
            var total = 0; // Just count the number of deletions using the ascii value
            this._deletions.ForEach(c => {
                total += c.GetAsciiValue();
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
                    this._deletions.Add(new DeletionInfo(DeletionInfoStringName.str1, letter, i));

                if (this._str1LettersCountDictionary.ContainsKey(letter)) // Just count the number of letter
                    this._str1LettersCountDictionary[letter] += 1;
                else
                    this._str1LettersCountDictionary[letter] = 1;                    
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
                if (this._str1LettersCountDictionary.ContainsKey(letter) && _str1LettersCountDictionary[letter] > 0) 
                    this._str1LettersCountDictionary[letter] -= 1;
                else
                    this._deletions.Add(new DeletionInfo(DeletionInfoStringName.str2, letter, i));
            }

            // Check for letter that where twice or more in str1 but once in str2
            // Check for letter that where twice or more in str2 but once in str1
            foreach(var e in _str1LettersCountDictionary)
            {
                if(e.Value > 0 && !this._deletions.Exists(d => d.Letter == e.Key))
                {
                    for(var i=0; i < e.Value; i++)
                        this._deletions.Add(new DeletionInfo(DeletionInfoStringName.unknown, e.Key, -1));
                }
            }
        }
    }
}
