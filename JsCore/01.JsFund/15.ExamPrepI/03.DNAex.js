function dnaEx(arr){
    let fullRegexPattern =/([!@#$?a-zA-Z]+)(?=\=)\=([0-9]+)\-\-([0-9]+)\<\<([0-9a-zA-Z]+)/g;
    let namePattern = /([!@#$?a-zA-Z]+)(?=\=)/g;
    let nameLengthPattern = /(?<=\=)([0-9]+)(?=[-]{2})/g;
    let genomesCountPattern = /(?<=[-]{2})([0-9]+)(?=[<]{2})/g;
    let organizmPattern = /(?<=[<]{2})([a-zA-Z0-9]+)(?=$)/g;

    let lettersPattern = /([a-zA-Z]+)/g;

    let genomeReg = {};

    //let arr = input.split(/\s+/)
    for (let i = 0; i < arr.length; i++) {
        let line = arr[i];
        if(line === "Stop!"){
            break;
        }
        let matchRegex = line.match(fullRegexPattern);

        if(matchRegex !== null){
            let name = line.match(namePattern)[0];
            let lettersFromName = name.match(lettersPattern);
                if(lettersFromName != null){
                    name = lettersFromName.join("");
                }
            
            let nameLength = +line.match(nameLengthPattern)[0];
            let genomesCount = +line.match(genomesCountPattern)[0];
            let organizm = line.match(organizmPattern)[0];

            if(name.length === nameLength){
                if(!genomeReg.hasOwnProperty(organizm)){
                genomeReg[organizm] = 0;
                }

                genomeReg[organizm] += genomesCount;
            }
        }
        
    }
    var sortable = [];
    for (var organizm in genomeReg) {
        sortable.push([organizm, genomeReg[organizm]]);
    }

    sortable.sort(function(a, b) {
        return b[1] - a[1];
    });
    for (const [key, value] of sortable) {
        console.log(`${key} has genome size of ${value}`);
    }
}

dnaEx("=12<<cat" + "\n" +
"!vi@rus?=2--142" + "\n" +
"?!cur##viba@cter!!=11--800<<cat" + "\n" +
"!fre?esia#=7--450<<mouse" + "\n" +
"@pa!rcuba@cteria$=13--351<<mouse" + "\n" +
"!richel#ia??=8--900<<human" + "\n" +
"Stop!");