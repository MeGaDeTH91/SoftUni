function info(){
    let resultCounts = {};

    for(let element of arguments){
        let type = typeof(element);
        if(!resultCounts.hasOwnProperty(type)){
            resultCounts[type] = 0;
        }
        resultCounts[type]++;

        console.log(`${type}: ${element}`);
    }

    let resultCountKeys = [];
    for(let currentType in resultCounts){
        resultCountKeys.push([currentType, resultCounts[currentType]]);
    }

    resultCountKeys = resultCountKeys.sort((a, b) => b[1] - a[1]);

    for (let i = 0; i < resultCountKeys.length; i++) {
        let key = resultCountKeys[i][0];
        let value = resultCountKeys[i][1];

        console.log(`${key} = ${value}`);
    }
}

info('cat', 42, function () { console.log('Hello world!'); }, 25, function () { console.log('Hello world!'); });