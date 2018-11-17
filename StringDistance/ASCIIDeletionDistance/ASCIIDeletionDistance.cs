using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicSugar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringDistances
{
    /// <summary>
    /// This class is based on the code https://repl.it/repls/IcyTragicSigns
    /// </summary>
    public class ASCIIDeletionDistance
    {
        /// <summary>
        /// Store all the letter to delete in str1 and str2
        /// </summary>
        List<DeletionInfo> _deletions = new List<DeletionInfo>();

        /// <summary>
        /// Store the count of letter in str1
        /// </summary>
        Dictionary<char, int> _str1LettersCountDictionary = new Dictionary<char, int>();

        /// <summary>
        /// Compute and return the ASCII Deletion Distance value and delete history
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public ASCIIDeletionDistanceResult Compute(string str1, string str2)
        {
            UpdateDeletionsAndLetterDictionaryPass1(str1, str2);
            UpdateDeletionsAndLetterDictionaryPass2(str2, str1);

            return new ASCIIDeletionDistanceResult()
            {
                Value = this.GetDeletionsCount(),
                History = this.BuildDeletionHistory()
            };
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

                // If a letter from str2 is in _str1LettersCountDictionary with a value > 0
                // This mean the letter was in both string. Once the counter reach 0, this
                // mean the letter is str2 but in str1
                if (this._str1LettersCountDictionary.ContainsKey(letter) && _str1LettersCountDictionary[letter] > 0) 
                    this._str1LettersCountDictionary[letter] -= 1;
                else
                    this._deletions.Add(new DeletionInfo(DeletionInfoStringName.str2, letter, i));
            }

            // Check for letter that where twice in str1 but once in str2 (or more...)
            // Check for letter that where twice in str2 but once in str1 (or more...)
            foreach(var e in _str1LettersCountDictionary)
            {
                if(e.Value > 0 && !this._deletions.Exists(d => d.Letter == e.Key))
                {
                    for(var i=0; i < e.Value; i++)
                        this._deletions.Add(new DeletionInfo(DeletionInfoStringName.str1, e.Key, -1));
                }
            }
        }
        
        private string BuildDeletionHistory()
        {
            var b = new StringBuilder();
            foreach(var d in this._deletions) 
                b.Append(d.ToString()).AppendLine();
            return b.ToString();
        }

        private int GetDeletionsCount()
        {
            var total = 0; // Just count the number of deletions using the ascii value
            this._deletions.ForEach(c => {
                total += c.GetAsciiValue();
            });
            return total;
        }
    }
}
