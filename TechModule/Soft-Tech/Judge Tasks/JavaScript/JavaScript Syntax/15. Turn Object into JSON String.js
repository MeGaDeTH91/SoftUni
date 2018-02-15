function solve(arr) {
    "use strict";
    let result = {};
    arr.map(a => a.split(' -> ')).forEach(studToken => {
        let props = studToken[0];
        let value = isNaN(studToken[1]) ? studToken[1] : Number(studToken[1]);
        result[props] = value;
    });
    console.log(JSON.stringify(result));
}
let input = ('name -> Angel\n' +
    'surname -> Georgiev\n' +
    'age -> 20\n' +
    'grade -> 6.00\n' +
    'date -> 23/05/1995\n' +
    'town -> Sofia').split('\n');
solve(input);