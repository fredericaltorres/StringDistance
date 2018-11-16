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
    public class FisherWagner
    {
        /////////////////////////////////////////////////////
        /// https://stackoverflow.com/questions/30792428/wagner-fischer-algorithm
        /// https://www.programcreek.com/2013/12/edit-distance-in-java/

        public int ComputeFisherWagner(string word1, string word2)
        {
            int len1 = word1.Length;
	        int len2 = word2.Length;
 
            int[,] dp = new int[len1 + 1, len2 + 1];
 
            for (int i = 0; i <= len1; i++) {
		        dp[i, 0] = i;   // the distance of any first string to an empty second string
                                // (transforming the string of the first i characters of s into
                                // the empty string requires i deletions)
	        }
 
	        for (int j = 0; j <= len2; j++) {
		        dp[0, j] = j; // the distance of any second string to an empty first string
	        }

            //iterate though, and check last char
	       for (int i = 0; i < len1; i++) {

		        char c1 = word1[i];

		        for (int j = 0; j < len2; j++) {

			        char c2 = word2[j];
			        if (c1 == c2) { // if last two chars equal
				        // update dp value for +1 length
				        dp[i + 1, j + 1] = dp[i, j];
			        }
                    else {
				        int replace = dp[i, j] + 1;
				        int insert  = dp[i, j + 1] + 1;
				        int delete  = dp[i + 1, j] + 1;
 
				        int min = replace > insert ? insert : replace;
				        min = delete > min ? min : delete;
				        dp[i + 1, j + 1] = min;
			        }
		        }
	        }
	        return dp[len1, len2];
        }
    }
}
/*
 for (int i = 0; i < len1; i++) {
		        char c1 = word1[i];
		        for (int j = 0; j < len2; j++) {
			        char c2 = word2[j];
 
			        //if last two chars equal
			        if (c1 == c2) {
				        //update dp value for +1 length
				        dp[i + 1, j + 1] = dp[i, j];
			        } else {
				        int replace = dp[i, j] + 1;
				        int insert = dp[i, j + 1] + 1;
				        int delete = dp[i + 1, j] + 1;
 
				        int min = replace > insert ? insert : replace;
				        min = delete > min ? min : delete;
				        dp[i + 1, j + 1] = min;
			        }
		        }
	        }
     */