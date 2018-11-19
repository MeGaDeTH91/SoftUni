let solution = (function vector(){
    function add(vec1, vec2){
        let result = [];
        result[0] = +vec1[0] + +vec2[0];
        result[1] = +vec1[1] + +vec2[1];

        return result;
    };
    function multiply(vec1, vec2){
        let result = [];
        result[0] = +vec1[0] * +vec2;
        result[1] = +vec1[1] * +vec2;
        
        return result;
    };
    function length(vec){
        let result = Math.sqrt(Math.pow(+vec[0], 2) + Math.pow(+vec[1], 2));
        return result;
    };
    function dot(vec1, vec2){
        let result = +vec1[0] * +vec2[0] + (vec1[1] * +vec2[1]);

        return result;
    };
    function cross(vec1, vec2){
        let result = +vec1[0] * +vec2[1] - +vec1[1] * +vec2[0];

        return result;
    };

    let resultObj = {add, multiply, length, dot, cross};
    return resultObj;
})();

console.log(solution.dot([2, 3], [2, -1]));