function wareHouse(arr){
    let wareHouse = {};

    for (let i = 0; i < arr.length; i++) {
        let lineTokens = arr[i].split(", ");

        let command = lineTokens[0];

        if (command === `IN`) {
            let coffeeBrand = lineTokens[1];
            let coffeeName = lineTokens[2];
            let expireDate = lineTokens[3];
            let quantity = +lineTokens[4];

            if (!wareHouse.hasOwnProperty(coffeeBrand)) {
                wareHouse[coffeeBrand] = {};
            }
            if (!wareHouse[coffeeBrand].hasOwnProperty(coffeeName)) {
                wareHouse[coffeeBrand][coffeeName] = {};
            }
            if (!wareHouse[coffeeBrand][coffeeName].hasOwnProperty("expireDate")) {
                wareHouse[coffeeBrand][coffeeName]["expireDate"] = expireDate;
            }
            if (!wareHouse[coffeeBrand][coffeeName].hasOwnProperty("quantity")) {
                wareHouse[coffeeBrand][coffeeName]["quantity"] = 0;
            }
            if (wareHouse[coffeeBrand][coffeeName]["expireDate"] === expireDate) {
                wareHouse[coffeeBrand][coffeeName]["quantity"] += quantity;
            }
            if (wareHouse[coffeeBrand][coffeeName]["expireDate"] < expireDate) {
                wareHouse[coffeeBrand][coffeeName]["expireDate"] = expireDate;
                wareHouse[coffeeBrand][coffeeName]["quantity"] = quantity;
            }

        } else if (command === `OUT`) {
            let coffeeBrand = lineTokens[1];
            let coffeeName = lineTokens[2];
            let expireDate = lineTokens[3];
            let quantity = +lineTokens[4];

            if (wareHouse.hasOwnProperty(coffeeBrand)) {
                if (wareHouse[coffeeBrand].hasOwnProperty(coffeeName)) {
                    if (wareHouse[coffeeBrand][coffeeName]["expireDate"] > expireDate) {
                        if (wareHouse[coffeeBrand][coffeeName]["quantity"] >= quantity) {
                            wareHouse[coffeeBrand][coffeeName]["quantity"] -= quantity;
                        }
                    }
                }
            }
        } else if (command === `REPORT`) {
            console.log(`>>>>> REPORT! <<<<<`);

            let brands = Object.entries(wareHouse);

            for (let brand of brands) {
                let brandName = brand[0];
                console.log(`Brand: ${brandName}:`);

                let brandCoffees = Object.entries(wareHouse[brandName]);
                for (let coffeeParams of brandCoffees) {
                    let coffeeName = coffeeParams[0];
                    let coffeeDetails = coffeeParams[1];

                    let expireDate = coffeeDetails["expireDate"];
                    let quantity = coffeeDetails["quantity"];

                    console.log(`-> ${coffeeName} -> ${expireDate} -> ${quantity}.`);
                }
            }

        } else if (command === `INSPECTION`) {
            console.log(`>>>>> INSPECTION! <<<<<`);

            let sortedBrands = Object.keys(wareHouse).sort();

            for (let brandName of sortedBrands) {

                let sortedCoffees = Object.keys(wareHouse[brandName]).sort((a, b) => wareHouse[brandName][b]["quantity"] - wareHouse[brandName][a]["quantity"]);

                console.log(`Brand: ${brandName}:`);

                for (let coffeeName of sortedCoffees) {
                    let coffeeDetails = wareHouse[brandName][coffeeName];

                    let expireDate = coffeeDetails["expireDate"];
                    let quantity = coffeeDetails["quantity"];

                    console.log(`-> ${coffeeName} -> ${expireDate} -> ${quantity}.`);
                }
            }
        }
    }
}

wareHouse([
        "IN, Batdorf & Bronson, Espresso, 2025-05-25, 20",
        "IN, Folgers, Black Silk, 2023-03-01, 14",
        "IN, Lavazza, Crema e Gusto, 2023-05-01, 5",
        "IN, Lavazza, Crema e Gusto, 2023-05-02, 5",
        "IN, Folgers, Black Silk, 2022-01-01, 10",
        "IN, Lavazza, Intenso, 2022-07-19, 20",
        "OUT, Dallmayr, Espresso, 2022-07-19, 5",
        "OUT, Dallmayr, Crema, 2022-07-19, 5",
        "OUT, Lavazza, Crema e Gusto, 2020-01-28, 2",
        "REPORT",
        "INSPECTION",
    ]
);