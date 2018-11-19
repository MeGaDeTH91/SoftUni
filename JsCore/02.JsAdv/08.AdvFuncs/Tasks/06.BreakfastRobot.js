let result = (function bake(){
    let ingredients = {
        'protein' : 0,
        'carbohydrate' : 0,
        'fat' : 0,
        'flavour' : 0
    };

    return function parseCommand(commandLine){
        if(commandLine === undefined){
            return;
        } else{
            let commTokens = commandLine.split(" ");
            let command = commTokens[0];
            if(command === 'restock'){
                let restockIngr = commTokens[1];
                let restockQuantity = +commTokens[2];
                return restockRobot(restockIngr, restockQuantity);
            } else if(command === 'prepare'){
                let prepFood = commTokens[1];
                let prepQuantity = +commTokens[2];
                return prepare(prepFood, prepQuantity);
            } else if(command === 'report'){
                return reportAtOnce();
            }
        }
    };

    function restockRobot(ingredient, quantity){
        ingredients[ingredient] += quantity;
         return "Success";
    }
    function prepare(food, quantity){
        if(food === 'apple'){
            if(quantity > ingredients['carbohydrate']){
                return `Error: not enough carbohydrate in stock`;
            } else if(quantity * 2 > ingredients['flavour']){
                return `Error: not enough flavour in stock`;
            } else{
                ingredients['carbohydrate'] -= quantity;
                ingredients['flavour'] -= quantity * 2;
                return 'Success';
            }
        } else if(food === 'coke'){
            if(quantity * 10 > ingredients['carbohydrate']){
                return `Error: not enough carbohydrate in stock`;
            } else if(quantity * 20 > ingredients['flavour']){
                return `Error: not enough flavour in stock`;
            } else{
                ingredients['carbohydrate'] -= quantity * 10;
                ingredients['flavour'] -= quantity * 20;
                return 'Success';
            }
        } else if(food === 'burger'){
            if(quantity * 5 > ingredients['carbohydrate']){
                return `Error: not enough carbohydrate in stock`;
            } else if(quantity * 7 > ingredients['fat']){
                return `Error: not enough fat in stock`;
            } else if(quantity * 3 > ingredients['flavour']){
                return `Error: not enough flavour in stock`;
            } else{
                ingredients['carbohydrate'] -= quantity * 5;
                ingredients['fat'] -= quantity * 7;
                ingredients['flavour'] -= quantity * 3;
                return 'Success';
            }
        } else if(food === 'omelet'){
            if(quantity * 5 > ingredients['protein']){
                return `Error: not enough protein in stock`;
            } else if(quantity > ingredients['fat']){
                return `Error: not enough fat in stock`;
            } else if(quantity > ingredients['flavour']){
                return `Error: not enough flavour in stock`;
            } else{
                ingredients['protein'] -= quantity * 5;
                ingredients['fat'] -= quantity;
                ingredients['flavour'] -= quantity;
                return 'Success';
            }
        } else if(food === 'cheverme'){
            if(quantity * 10 > ingredients['protein']){
                return `Error: not enough protein in stock`;
            } else if(quantity * 10 > ingredients['carbohydrate']){
                return `Error: not enough carbohydrate in stock`;
            } else if(quantity * 10 > ingredients['fat']){
                return `Error: not enough fat in stock`;
            } else if(quantity * 10 > ingredients['flavour']){
                return `Error: not enough flavour in stock`;
            } else{
                ingredients['protein'] -= quantity * 10;
                ingredients['carbohydrate'] -= quantity * 10;
                ingredients['fat'] -= quantity * 10;
                ingredients['flavour'] -= quantity * 10;
                return'Success';
            }
        }
    }
    function reportAtOnce(){
        return `protein=${ingredients['protein']} carbohydrate=${ingredients['carbohydrate']} fat=${ingredients['fat']} flavour=${ingredients['flavour']}`;
    }
})();

result("restock carbohydrate 10");
result("restock flavour 10");
result("prepare apple 1");
result("restock fat 10");
result("prepare burger 1");
result("report");