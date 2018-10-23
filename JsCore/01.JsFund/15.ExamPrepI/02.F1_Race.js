function f1Race(arr){
    let pilots = arr[0].split(/\s+/);

    for (let i = 1; i < arr.length; i++) {
        let line = arr[i].split(/\s+/);
        
        let command = line[0];
        let pilot = line[1];
        
        switch (command) {
                case "Join":
                if(!pilots.includes(pilot)){
                    pilots.push(pilot);
                }
                break;
                case "Crash":
                if(pilots.includes(pilot)){
                    pilots = pilots.filter(x => x != pilot);
                }
                break;
                case "Pit":
                if(pilots.includes(pilot)){
                    let index = pilots.indexOf(pilot);
                    if(index < pilots.length - 1){
                        let pitted = pilots[index];
                        pilots[index] = pilots[index + 1];
                        pilots[index + 1] = pitted;
                    }
                }
                break;
                case "Overtake":
                if(pilots.includes(pilot)){
                    let index = pilots.indexOf(pilot);
                    if(index > 0){
                        let pitted = pilots[index];
                        pilots[index] = pilots[index - 1];
                        pilots[index - 1] = pitted;
                    }
                }
                break;
            default:
                break;
        }
    }
    console.log(pilots.join(" ~ "));
}

f1Race(["Vetel Hamilton Raikonnen Botas Slavi",
"Pit Hamilton",
"Overtake LeClerc",
"Join Ricardo",
"Crash Botas",
"Overtake Ricardo",
"Overtake Ricardo",
"Overtake Ricardo",
"Crash Slavi"]
);