using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicSugar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringDistances
{
    /*
      ASCII Deletion Distanc eDynamic Programming
      ===========================================
      Based on the Fisher Wagner algo but simpler we can solve the problem
      using dynamic programming
      1. Create a matrix for the 2 word
      2. For each row check if the row letter is in one of the column if yes mark the column with a 1 if all column value are 0 (else duplicate letter)
      3. For each row if all column contain a 0 the letter was not used we must delete it
      4. For each col if all row contain a 0 the letter was not used we must delete it

    Sample 1:
        b r e a d
    g   0 0 0 0 0 delete g
    r   0 1 0 0 0 keep r
    e   0 0 1 0 0 keep e
    d   0 0 0 0 1 keep d
    
        delelte b, keep r, keep e delete a, keep d
        delete char g, b, a

    Sample 2:
        c a t
    b   0 0 0 delete b
    a   0 1 0 keep a
    t   0 0 1 keep t
        delete c
        delete chars b,c             

    Sample 3:
        b a t
    c   0 0 0 delete c
    a   0 1 0 keep a
    t   0 0 1 keep t
    a   0 0 0 delete a
    
delete c, delete second a, delete b

*/

    public class ASCIIDeletionDistanceDynamicProgramming
    {
        /// <summary>
        /// Store all the letter to delete in str1 and str2
        /// </summary>
        private List<int> _deletions = new List<int>();

        private bool IsRowAll0(int[,] matrix, int row, int maxCol)
        {
            for(var j=0; j < maxCol; j++) 
                if(matrix[row, j] != 0)
                    return false;
            return true;
        }

        private bool IsColAll0(int[,] matrix, int col, int maxRow)
        {
            for(var i=0; i < maxRow; i++) 
                if(matrix[i, col] != 0)
                    return false;
            return true;
        }

        public FisherWagner.FisherWagnerResult Compute(string word1, string word2)
        {
            int len1 = word1.Length;
	        int len2 = word2.Length;
 
            int[,] dp = new int[len1, len2]; // Will be filled with 0

	        for (int i = 0; i < len1; i++)
            {
		        char c1 = word1[i];
		        for (int j = 0; j < len2; j++) {
			        char c2 = word2[j];
                    if(c1 == c2)
                    {
                        if(IsColAll0(dp, j, len1))
                            dp[i, j] = 1;
                    }
		        }
	        }

            for (int i = 0; i < len1; i++)
            {
		        char c = word1[i];
                if(IsRowAll0(dp, i, len2))
                    this._deletions.Add(c);
	        }

            for (int j = 0; j < len2; j++)
            {
                char c = word2[j];
                if(IsColAll0(dp, j, len1))
                    this._deletions.Add(c);
	        }

            return new FisherWagner.FisherWagnerResult ()
            {
                Value = this.GetDeletionsCount(),
                Matrix = dp
            };
        }        

        private int GetDeletionsCount()
        {
            var total = 0; // Just count the number of deletions using the ascii value
            this._deletions.ForEach(c => {
                total += c;
            });
            return total;
        }
    }

}
