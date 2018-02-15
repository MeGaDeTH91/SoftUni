function solve(arr) {
    "use strict";
    let students = arr.map(JSON.parse);
    students.forEach(element => {
        "use strict";
        console.log("Name: " + element.name + "\n" +
            "Age: " + element.age + "\n" +
            "Date: " + element.date)
    });
}
let input = ['{"name":"Gosho","age":10,"date":"19/06/2005"}\n',
'{"name":"Tosho","age":11,"date":"04/04/2005"}'];
solve(input);