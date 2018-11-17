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
    };
}
