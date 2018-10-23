function kompot(arr){
    let fruits = {};

    fruits["Cherry kompots"] = 0;
    fruits["Peach kompots"] = 0;
    fruits["Plum kompots"] = 0;
    fruits["Rakiya liters"] = 0.0;

    for (let i = 0; i < arr.length; i++) {
        let lineTokens = arr[i].split(/\s+/);
        
        let fruit = lineTokens[0];
        let quantity = +lineTokens[1];

        if(fruit === "cherry"){
            fruits["Cherry kompots"] += quantity;
        } else if(fruit === "peach"){
            fruits["Peach kompots"] += quantity;
        } else if(fruit === "plum"){
            fruits["Plum kompots"] += quantity;
        } else {
            fruits["Rakiya liters"] += quantity;
        }
    }

    let fruitKeys = Object.keys(fruits);

    for (let i = 0; i < fruitKeys.length; i++) {
        let fruit = fruitKeys[i];
        
        if(fruit === "Cherry kompots"){
            fruits["Cherry kompots"] = Math.floor(parseFloat(`${(fruits["Cherry kompots"] / 0.009) / 25}`)).toFixed(0);
            console.log(`${fruit}: ${fruits["Cherry kompots"]}`);
        } else if(fruit === "Peach kompots"){
            fruits["Peach kompots"] = Math.floor(parseFloat(`${(fruits["Peach kompots"] / 0.140) / 2.5}`)).toFixed(0);
            console.log(`${fruit}: ${fruits["Peach kompots"]}`);
        } else if(fruit === "Plum kompots"){
            fruits["Plum kompots"] = Math.floor(parseFloat(`${(fruits["Plum kompots"] / 0.020) / 10}`)).toFixed(0);
            console.log(`${fruit}: ${fruits["Plum kompots"]}`);
        } else {
            fruits["Rakiya liters"] = parseFloat(`${fruits["Rakiya liters"] * 0.2}`).toFixed(2);
            console.log(`${fruit}: ${fruits["Rakiya liters"]}`);
        }
    }
}

kompot([ 'cherry 1.2',
'peach 2.2', 
'plum 5.2',
'peach 0.1', 
'cherry 0.2', 
'cherry 5.0', 
'plum 10',
'cherry 20.0' ,
'papaya 20' ]
);