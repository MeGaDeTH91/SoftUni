function coffee(arr){
    let coffeeWithCaffeinePrice = 0.80;
    let coffeeDecafPrice = 0.90;
    let teaPrice = 0.80;

    let totalIncome = 0.0;

    for (let i = 0; i < arr.length; i++) {
        let lineTokens = arr[i].split(", ");

        let coinInserted = +lineTokens[0];
        let drinkType = lineTokens[1];

        let sugar = 0;

        let currentDrinkPrice = 0.0;

        if(drinkType === "coffee"){
            let coffeeType = lineTokens[2];

            if(coffeeType === 'caffeine'){
                currentDrinkPrice = coffeeWithCaffeinePrice;
            } else if(coffeeType === 'decaf'){
                currentDrinkPrice = coffeeDecafPrice;
            }

            if(lineTokens.includes('milk')){
                sugar = +lineTokens[4];
                currentDrinkPrice = currentDrinkPrice + +((currentDrinkPrice * 0.1).toFixed(1));
            } else{
                sugar = +lineTokens[3];
            }

            if(sugar > 0){
                currentDrinkPrice += 0.10;
            }

            if(coinInserted >= currentDrinkPrice){
                totalIncome += currentDrinkPrice;
                coinInserted-= currentDrinkPrice;

                console.log(`You ordered ${drinkType}. Price: ${currentDrinkPrice.toFixed(2)}$ Change: ${coinInserted.toFixed(2)}$`);
            }else{
                let diff = currentDrinkPrice - coinInserted;
                console.log(`Not enough money for ${drinkType}. Need ${diff.toFixed(2)}$ more.`);
            }

        } else if(drinkType === "tea"){
            currentDrinkPrice = teaPrice;

            if(lineTokens.includes('milk')){
                sugar = +lineTokens[3];
                currentDrinkPrice = currentDrinkPrice + +((currentDrinkPrice * 0.1).toFixed(1));
            } else{
                sugar = +lineTokens[2];
            }

            if(sugar > 0){
                currentDrinkPrice += 0.10;
            }
            if(coinInserted >= currentDrinkPrice){
                totalIncome += currentDrinkPrice;
                coinInserted-= currentDrinkPrice;

                console.log(`You ordered ${drinkType}. Price: ${currentDrinkPrice.toFixed(2)}$ Change: ${coinInserted.toFixed(2)}$`);
            }else{
                let diff = currentDrinkPrice - coinInserted;
                console.log(`Not enough money for ${drinkType}. Need ${diff.toFixed(2)}$ more.`);
            }
        }



    }

    console.log(`Income Report: ${totalIncome.toFixed(2)}$`);
}

coffee(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2',
    '1.00, coffee, decaf, 0']
);