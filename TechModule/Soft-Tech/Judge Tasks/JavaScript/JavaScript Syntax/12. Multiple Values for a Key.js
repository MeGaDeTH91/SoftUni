function solve(arr) {
    let searched = arr[arr.length-1];
    let pairs = arr.slice(0, -1).map(keyValuePair);
    let dict = {};
    pairs.forEach(element => {
        "use strict";
        if(!dict[element.key])
        {
            dict[element.key] = [];
        }
        dict[element.key].push(element.value);
    });
    if(dict[searched])
    {
        console.log(dict[searched].join('\n'));
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