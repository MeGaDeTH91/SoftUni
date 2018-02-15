function solve(arr) {
    let registry = arr.map(parseStudents);
    function parseStudents(str) {
        let tokens = str.split(' -> ');
        let obj = {};
        let name = tokens[0];
        let age = tokens[1];
        let grade = tokens[2];
        obj = {name:name, age:age, grade:grade};
        return obj;
    }
    registry.forEach(element => {
        "use strict";
        console.log("Name: " + element.name + "\n" +
            "Age: " + element.age + "\n" +
            "Grade: " + element.grade)
    });
}