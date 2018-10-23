function invertory(arr){
    let allHeroes = [];

    for (let i = 0; i < arr.length; i++) {
        let heroTokens = arr[i].split(" / ");
        let heroItems = heroTokens[2].split(", ");

        let currentHero = {
            name:heroTokens[0],
            level:heroTokens[1],
            items:heroItems
        }
        allHeroes.push(currentHero);
    }

    console.log("Ass")
}

invertory(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
);