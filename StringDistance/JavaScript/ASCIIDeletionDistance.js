/*
    Base from https://repl.it/repls/IcyTragicSigns
    But fixed bug
*/

function ArrayContains(arr, val) {
    return arr.indexOf(val) !== -1;
}

function ascii_deletion_distance(str1, str2) {

    const deletions = [];
    const str1Letters = {};

    console.log(`ascii_deletion_distance str1:${str1}, str2:${str2}`);

    // loop through the string, adding each letter to the object
    for (let i = 0; i < str1.length; i++) {
        const letter = str1[i];
        if (!str2.includes(letter))
            deletions.push(letter);
        if (str1Letters[letter]) 
            str1Letters[letter] += 1;
        else 
            str1Letters[letter] = 1;
    }

    console.log(`str1:${str1} deletions:${JSON.stringify(deletions)}`);
    console.log(`str1:${str1} str1Letters:${JSON.stringify(str1Letters)}`);

    // check if the object has each letter, with the same frequency
    // if not, add it to the deletions list
    for (let j = 0; j < str2.length; j++) {
        const letter = str2[j];
        if (str1Letters[letter])
            str1Letters[letter] -= 1;
        else
            deletions.push(letter);
    }

    // Check for letter that where twice in str1 but once in str2
    Object.keys(str1Letters).forEach( (letter) => {
        if(str1Letters[letter] > 0 && !ArrayContains(deletions, letter))
            deletions.push(letter);
    });

    console.log(`str2:${str2} deletions:${JSON.stringify(deletions)}`);
    console.log(`str2:${str2} str1Letters:${JSON.stringify(str1Letters)}`);

    return deletions.reduce((total, currLetter) => {
        return total += currLetter.charCodeAt();
    }, 0);
}
console.log(ascii_deletion_distance('cat', 'batzz'));
//console.log(ascii_deletion_distance('cat', 'batz'))
//console.log(ascii_deletion_distance('cata', 'bat'));
//console.log(ascii_deletion_distance('cat', 'bat'));
// console.log(ascii_deletion_distance('at', 'cat'));
// console.log(ascii_deletion_distance('thought', 'slough'));
/*
'cat' and 'bat'
1) create the dic {a:1, t:1}
2) foreach in cat if c in dic dec else remove c
*/