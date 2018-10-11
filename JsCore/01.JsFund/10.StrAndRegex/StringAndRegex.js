// 01. Split a String with a Delimiter
function split(arr, delimiter){
    let resultArr = arr.split(delimiter);
    console.log(resultArr.join("\n"));
}

// 02. Repeat a String N Times
function repeatNTimes(text, times){
    console.log(text.repeat(times));
}

// 03. Starts With
function startsWith(text, check){
    if(text.startsWith(check)){
        console.log(true);
    } else{
        console.log(false);
    }
}

// 04. Ends With
function endsWith(text, check){
    if(text.endsWith(check)){
        console.log(true);
    } else{
        console.log(false);
    }
}

// 05. Capitalize the Words
function capitalize(text){
    let arr = text.split(" ");

    let resultArr = [];

    for (let i = 0; i < arr.length; i++) {
        let element = arr[i].charAt(0).toUpperCase() + arr[i].toLowerCase().slice(1);
        
        resultArr.push(element);
    }

    console.log(resultArr.join(" "));
}

// 06. Capture the Numbers
function captureNums(text){
    let regexPattern = /\d+/g;

    let regex = new RegExp(regexPattern);

    let resultArr = [];

    for (let i = 0; i < text.length; i++) {
        let element = text[i];
        
        let match = regex.exec(element);

        while(match){
            resultArr.push(match[0]);
            match = regex.exec(element)
        }
    }

    console.log(resultArr.join(" "));
}

// 07. Find Variable Names in Sentences
function findNames(text){
    let regexPattern = "\\b_([a-zA-Z0-9]+)\\b" ;

    let regex = new RegExp(regexPattern,"g");

    let resultArr = [];

    let match = regex.exec(text);
    while(match){
        resultArr.push(match[1]);

        match = regex.exec(text);
    }

    console.log(resultArr.join(","));
}

// 08. Word Occurences
function occurences(text, search){
    text = text.toLowerCase();
    search = search.toLowerCase();

    let regex = new RegExp("\\b" + search + "\\b", "g");

    let counter = 0;

    match = regex.exec(text);

    while(match){
        counter++;

        match = regex.exec(text);
    }

    console.log(counter);
}

// 09. Extract Links
function links(arr){
    let pattern = /www\.([a-zA-Z0-9\-]+\.)+[a-z]+/g;

    let regex = new RegExp(pattern);

    for (let i = 0; i < arr.length; i++) {
        let element = arr[i];

        let match = regex.exec(element);

        while(match){
            console.log(match[0]);

            match = regex.exec(element);
        }
    }
}

// 10. Secret Data
function secretData(arr){
    let clientNamePattern = /\*[A-Z][a-zA-Z]*(?= \t| |$)/g;
    let phonePattern = /\+[0-9-]{10}(?= \t| |$)/g;
    let clientIdPattern = /\![a-zA-Z0-9]+(?= \t| |$)/g;
    let secretBasesPattern = /\_[a-zA-Z0-9]+(?= \t| |$)/g;

    let resultArr = [];

    let replaceSymbol = `|`;

    for (let sentence of arr) {
        sentence = sentence
            .replace(clientNamePattern, m => "|".repeat(m.length))                   
            .replace(phonePattern, m => "|".repeat(m.length))
            .replace(clientIdPattern, m => "|".repeat(m.length))
            .replace(secretBasesPattern, m => "|".repeat(m.length));

        console.log(sentence);
    }
}

secretData(['Agent *Ivankov was in the room when it all happened.', 
'The person in the room was heavily armed.', 
'Agent *Ivankov had to act quick in order.', 
'He picked up his phone and called some unknown number.',
'I think it was +555-49-796', 
'I can\'t really remember...', 
`He said something about "finishing work"`, 'with subject !2491a23BVB34Q and returning to Base _Aurora21', 
'Then after that he disappeared from my sight.', 
'As if he vanished in the shadows.', 
'A moment, shorter than a second, later, I saw the person flying off the top floor.', 
'I really don\'t know what happened there.', 
'This is all I saw, that night.', 
'I cannot explain it myself...']
);