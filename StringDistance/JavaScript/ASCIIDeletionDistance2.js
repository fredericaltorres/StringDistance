/*
The deletion distance between two strings is the minimum sum of ASCII values of characters that you need to delete in the two strings in order to have the same string. The deletion distance between "cat" and "at" is 99, because you can just delete the first character of cat and the ASCII value of 'c' is 99. The deletion distance between "cat" and "bat" is 98 + 99, because you need to delete the first character of both words. Of course, the deletion distance between two strings can't be greater than the sum of their total ASCII values, because you can always just delete both of the strings entirely.
 
Implement an efficient function to find the deletion distance between two strings.
 
You can refer to the Wikipedia article on the algorithm for edit distance if you want to. The algorithm there is not quite the same as the algorithm required here, but it's similar.
*/


function ascii_deletion_distance(str1, str2) {
    // consider the strings as char arrays
    // we need to get the ORDERED intersection of the arrays
    // and build the difference while figuring out the ordered intersection
    var deleted = [];
    debugger;
    var last;
    while (str1 !== str2) {
        last = 0;
        str1 = str1.split('').filter(function (char) {



            last = str2.indexOf(char, last) + 1;
            // THERE IS A BUG HERE because last can become to big for the next search
            // For the case 'thought', 'slough'))

            if (last === 0) {
                console.log(`pass 1 delete [${last}] ${char}`)
                deleted.push(char);
                return false;
            } else {
                console.log(`pass 1 keep [${last}] ${char}`)
                return true;
            }
        }).join('');

        last = 0;
        str2 = str2.split('').filter(function (char) {
            last = str1.indexOf(char, last) + 1;
            if (last === 0) {
                console.log(`pass 2 delete ${char}`)
                deleted.push(char);
                return false;
            } else {
                return true;
            }
        }).join('');

        console.log(`end of pass 2 '${str1}' '${str2}'\r\n`);

    }
    deleted = deleted.join('');
    var sum = 0;
    for (var i = 0; i < deleted.length; i++) {
        sum += deleted.charCodeAt(i);
    }
    //if (sum > 1000){sum = sum/2}
    return sum;
}
console.log('====================');
// sample test cases
// 'at', 'cat'          // pass
// 'bread', 'gred'      // pass
// 'thought', 'sloughs' // fail

console.log(ascii_deletion_distance('thought', 'slough'))