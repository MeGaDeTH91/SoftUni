function f1Champs(arr){
    let championship = {};

    for (let i = 0; i < arr.length; i++) {
        let lineTokens = arr[i].split(" -> ");

        let team = lineTokens[0];
        let pilot = lineTokens[1];
        let points = +lineTokens[2];

        if(!championship.hasOwnProperty(team)){
            championship[team] = {
                totalPoints : 0,
                pilots : {}
            };
        }
        if(!championship[team]["pilots"].hasOwnProperty(pilot)){
            championship[team]["pilots"][pilot] = 0;
        }
        championship[team]["totalPoints"] += points;
        championship[team]["pilots"][pilot] += points;
    }

    let sortedTeams = Object.entries(championship).sort((a, b) => b[1]["totalPoints"] - a[1]["totalPoints"]).slice(0, 3);

    for (const teamName of sortedTeams) {
        let sortedPilots = Object.entries(teamName[1]["pilots"]).sort((a, b) => b[1] - a[1])
        console.log(`${teamName[0]}: ${teamName[1]["totalPoints"]}`)

        for (let [pilot, points] of sortedPilots) {
            console.log(`-- ${pilot} -> ${points}`);
        }
    }
}

f1Champs(["Ferrari -> Kimi Raikonnen -> 25",
    "Ferrari -> Sebastian Vettel -> 18",
    "Mercedes -> Lewis Hamilton -> 10",
    "Mercedes -> Valteri Bottas -> 8",
    "Red Bull -> Max Verstapen -> 6",
    "Red Bull -> Daniel Ricciardo -> 4"]
);