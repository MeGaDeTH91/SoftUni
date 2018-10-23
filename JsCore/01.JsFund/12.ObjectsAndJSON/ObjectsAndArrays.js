// 01. Heroic Inventory
function invertory(arr){
    let allHeroes = [];

    for (let i = 0; i < arr.length; i++) {
        let heroTokens = arr[i].split(" / ");

        let heroName = heroTokens[0];
        let heroLevel = +heroTokens[1];
        let heroItems = [];

        if(heroTokens.length > 2){
            heroItems = heroTokens[2].split(", ");
        }

        let currentHero = {
            name:heroName,
            level:heroLevel,
            items:heroItems
            };

        allHeroes.push(currentHero);
    }

    console.log(JSON.stringify(allHeroes));
}

// invertory(['Isacc / 25 / Apple, GravityGun',
//     'Derek / 12 / BarrelVest, DestructionSword',
//     'Hes / 1 / Desolator, Sentinel, Antara']
// );

// 02. JSON's Table
function jsonTable(json){
    let data = [];

    let html = "<table>";

    for (let i = 0; i < json.length; i++) {
        let line = JSON.parse(json[i]);
        let lineValues = Object.values(line);
        html+="\n	<tr>"
        for (let j = 0; j < lineValues.length; j++) {
            let element = lineValues[j];

            html+=`\n		<td>${element}</td>`;
            
        }
        html+="\n	</tr>"
    }

    html += "\n</table>";

    console.log(html);
}

// jsonTable(['{"name":"Pesho","position":"Promenliva","salary":100000}',
// '{"name":"Teo","position":"Lecturer","salary":1000}',
// '{"name":"Georgi","position":"Lecturer","salary":1000}']
// );

// 03. Cappy Juice
function cappyJuice(arr){
    let juices = {};

    let resultJuices = {};

    for (let i = 0; i < arr.length; i++) {
        let line = arr[i].split(" => ");
        let juiceName = line[0];
        let juiceQuantity = +line[1];
        
        if(!(juiceName in juices)){
            juices[juiceName] = 0;
        }
        juices[juiceName] += juiceQuantity;

        if(juices[juiceName] >= 1000){
            resultJuices[juiceName] = juices[juiceName];
        }
    }

    let juiceNamesArr = Object.keys(resultJuices);
    
    for (let i = 0; i < juiceNamesArr.length; i++) {
        let juice = juiceNamesArr[i];
        
        let quantity = Math.floor(resultJuices[juice] / 1000);
            
            if(quantity >= 1){
                console.log(`${juice} => ${quantity}`)
            }
    }
}

// cappyJuice(['Orange => 2000',
// 'Peach => 1432',
// 'Banana => 450',
// 'Peach => 600',
// 'Strawberry => 549']
// );

// 04. Store Catalogue
function storeCatalog(arr){
    let firstLetters = [];
    
    let products = {};

    for (let i = 0; i < arr.length; i++) {
        let lineTokens = arr[i].split(" : ");

        let itemName = lineTokens[0];
        let itemPrice = +lineTokens[1];

        let firstLetter = Array.from(itemName)[0];
        if(!firstLetters.includes(firstLetter)){
            firstLetters.push(firstLetter);
        }
        

        products[itemName] = itemPrice;
    }

    let productKeys = Object.keys(products);

    firstLetters.sort((a,b) => a.localeCompare(b));
    productKeys.sort((a,b) => a.localeCompare(b));

    for (let i = 0; i < firstLetters.length; i++) {
        let element = firstLetters[i];

        console.log(element);

        for (let j = 0; j < productKeys.length; j++) {
            let product = productKeys[j];
            
            if(product.startsWith(element)){
                console.log(`  ${product}: ${products[product]}`);
            }
        }
        
    }

}

// storeCatalog(['Appricot : 20.4',
// 'Fridge : 1500',
// 'TV : 1499',
// 'Deodorant : 10',
// 'Boiler : 300',
// 'Apple : 1.25',
// 'Anti-Bug Spray : 15',
// 'T-Shirt : 10']
// );

// 05. Auto-Engineering Company
function engCompany(arr){
    let carRegistry = new Map();

    for (let i = 0; i < arr.length; i++) {
        let lineTokens = arr[i].split(" | ");
        
        let carBrand = lineTokens[0];
        let carModel = lineTokens[1];
        let producedCars = +lineTokens[2];

        if(!carRegistry.has(carBrand)){
            carRegistry.set(carBrand, new Map());
        }
        if(!carRegistry.get(carBrand).get(carModel)){
            carRegistry.get(carBrand).set(carModel, 0);
        }
        carRegistry.get(carBrand).set(carModel, carRegistry.get(carBrand).get(carModel) + producedCars);
    }

    for (const [brand, models] of carRegistry) {
        console.log(brand);

        for (const [modelName, modelCount] of models) {
            console.log(`###${modelName} -> ${modelCount}`);
        }
    }
}

// engCompany(['Audi | Q7 | 1000',
// 'Audi | Q6 | 100',
// 'BMW | X5 | 1000',
// 'BMW | X6 | 100',
// 'Citroen | C4 | 123',
// 'Volga | GAZ-24 | 1000000',
// 'Lada | Niva | 1000000',
// 'Lada | Jigula | 1000000',
// 'Citroen | C4 | 22',
// 'Citroen | C5 | 10']
// );

// 06. System Components
function system(arr){
    let systemReg = {};

    for (let i = 0; i < arr.length; i++) {
        let line = arr[i].split(" | ");
        
        let systemName = line[0];
        let componentName = line[1];
        let subComponentName = line[2];

        if(!systemReg.hasOwnProperty(systemName)){
            systemReg[systemName] = {};
        }
        if(!systemReg[systemName].hasOwnProperty(componentName.toLowerCase())){
            systemReg[systemName][componentName] = [];
        }

        systemReg[systemName][componentName].push(subComponentName);
    }

    for (const iterator of object) {
        
    }
}

// system(['SULS | Main Site | Home Page',
// 'SULS | Main Site | Login Page',
// 'SULS | Main Site | Register Page',
// 'SULS | Judge Site | Login Page',
// 'SULS | Judge Site | Submittion Page',
// 'Lambda | CoreA | A23',
// 'SULS | Digital Site | Login Page',
// 'Lambda | CoreB | B24',
// 'Lambda | CoreA | A24',
// 'Lambda | CoreA | A25',
// 'Lambda | CoreC | C4',
// 'Indice | Session | Default Storage',
// 'Indice | Session | Default Security']
// );

// 07. Usernames
function usernames(arr){
    let catalogue = new Set();

    arr.forEach(name => catalogue.add(name));

    let sortedNames = Array.from(catalogue)
    .sort((a,b) => a.length - b.length || a.localeCompare(b));
    console.log(sortedNames.join("\n"));
    
}

// usernames(['Ashton',
// 'Kutcher',
// 'Ariel',
// 'Lilly',
// 'Keyden',
// 'Aizen',
// 'Billy',
// 'Braston']
// );

// 08. Unique Sequences
function uniqueSeq(arr){
    let numberArrays = new Set();

    arr.sort((a, b) => a - b).forEach(x => numberArrays.add(x));

    console.log();
}

uniqueSeq(["[-3, -2, -1, 0, 1, 2, 3, 4]",
"[10, 1, -17, 0, 2, 13]",
"[4, -3, 3, -2, 2, -1, 1, 0]"]
);