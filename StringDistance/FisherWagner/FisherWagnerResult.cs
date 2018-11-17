namespace StringDistances
{



    public partial class FisherWagner
    {
        public class FisherWagnerResult
        {
            public int Value;
            public int[,] Matrix;
            public string MatrixAsString;
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

/*

Map for going from  "AB" to "FV"
# mean empty string
+-----+---+---+---+---+
|     |j->| 0 | 1 | 2 |
+-----+---+---+---+---+
|   i |   | # | F | V |
+-----+---+---+---+---+
|   0 | # | 0 | 1 | 2 |
|   1 | A | 1 | 1 | 2 |
|   2 | B | 2 | 2 | 2 |
+-----+---+---+---+---+ 
 
[0, 0] 0 step  to move from an "" to ""
[0, 1] 1 step  to move from an "" to "F"; Insert F
[0, 2] 2 steps to move from an "" to "FV"; Insert F and V

[1, 0] 1 step  to move from an "A" to ""; Delete A
[1, 1] 1 step  to move from an "A" to "F"; Replace A with F
[1, 2] 2 steps to move from an "A" to "FV"; Replace A with F, Insert V

[2, 0] 2 steps  to move from an "AB" to ""; Delete A, Delete B
[2, 1] 2 steps  to move from an "AB" to "F";Delete A, Replace B with F
[2, 2] 2 steps  to move from an "AB" to "FV";Replace A with F, Replace B with V

To caculate the number of steps to achive step [i, j], there is always 3 ways:
Let's try to compute [2, 2]
1. From [2, 1] => 2 + 1 (insert V) = 3, 
2. From [1, 2] => 2 + 1 (insert V) = 3, 
3. From [1, 1] => 1 + 1 (insert V) = 2, 
WRONG

---------------------------------
Base from https://en.wikipedia.org/wiki/Wagner%E2%80%93Fischer_algorithm

'sitting' 7 chars  to 'kitten' 6 chars

        *   k	i	t	t	e	n
        ---------------------------
        0	1	2	3	4	5	6   **
s   |	1	1_	2	3	4	5	6 
i   |	2	2	1_	2	3	4	5
t   |	3	3	2	1_	2	3	4
t   |	4	4	3	2	1_	2	3
i   |	5	5	4	3	2	2_	3
n   |	6	6	5	4	3	3	2_
g   |	7	7	6	5	4	4	3_

*   Row indexes
**  Col indexes

Steps: 
[1, 1] go from 's' to 'k' -> replace 'k' with 's' -> 1 op
[2, 2] go from 'i' to 'i' -> nothing -> use count from [1,1] + 0 = 1 op
[3, 3] go from 't' to 't' -> nothing -> use count from [2,2] + 0 = 1 op
[4, 4] go from 't' to 't' -> nothing -> use count from [3,3] + 0 = 1 op
[5, 5] go from 'i' to 'e' -> replace -> use count from [4,4] + 1 = 2 op
[6, 6] go from 'n' to 'n' -> nothing -> use count from [5,5] + 0 = 2 op
[6, 7] go from 'g' to ''  -> delete 'g' -> use count from [6,6] + 1 = 3 op

'sitting' 'kitten'
's'  'k'                replace s with k
'si' 'ki'               replace s with k, do nothing
'sit' 'kit'             replace s with k, do nothing, do nothing
'sitt' 'kitt'           replace s with k, do nothing, do nothing, do nothing
'sitti' 'kitte'         replace s with k, do nothing, do nothing, do nothing, replace i with e,
'sittin' 'kitten'       replace s with k, do nothing, do nothing, do nothing, replace i with e, do nothing,
'sitting' 'kitten'      replace s with k, do nothing, do nothing, do nothing, replace i with e, do nothing, delete g

 */    