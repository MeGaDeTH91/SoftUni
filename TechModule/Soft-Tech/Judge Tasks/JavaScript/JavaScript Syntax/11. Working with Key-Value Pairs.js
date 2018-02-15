function solve(arr) {
    let searched = arr[arr.length-1];
    let pairs = arr.slice(0, -1).map(keyValuePair);
    let dict = {};
    pairs.forEach(element => {
        "use strict";
        dict[element.key] = element.value;
    });
    if(dict[searched])
    {
        console.log(dict[searched]);
    }
    else
    {
        console.log("None");
    }

    function keyValuePair(str) {
        "use strict";
        let tokens = str.split(' ');
        let result = {key:tokens[0],
        value:tokens[1]};
        return result;
    }
}
let input = ('key value\n' +
             'key eulav\n' +
             'test tset\n' +
             'key').split("\n");
solve(input);