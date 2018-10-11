// 01. Inside Volume
function insVolume(arr){
    for(let i = 0; i < arr.length; i+=3){
        let x = arr[i];
        let y = arr[i + 1];
        let z = arr[i + 2];

        if(checkIfInside(x, y, z)){
            console.log("inside");
        }else{
            console.log("outside");
        }
    }

    function checkIfInside(x, y, z){
        let xMin = 10, xMax = 50;
        let yMin = 20, yMax = 80;
        let zMin = 15, zMax = 50;

        if(x >= xMin && x <= xMax &&
           y >= yMin && y <= yMax &&
           z >= zMin && z <= zMax){
               return true;
           }else{
               return false;
           }
    }
}

// 02. Road Radar
function radar(arr){
    let speed = +arr[0];
    let road = arr[1];

    let speedLimit = getSpeedLimit(road);

    let diff = speed - speedLimit;


    if(diff > 0 && diff <= 20){
        console.log("speeding");
    } else if(diff > 0 && diff <= 40){
        console.log("excessive speeding");
    } else if(diff > 0){
        console.log("reckless driving");
    }

    function getSpeedLimit(road){
        switch(road){
            case 'motorway' : return 130;
            case 'interstate' : return 90;
            case 'city' : return 50;
            case 'residential' : return 20;
        }
    }
}

// 03. Template Format
function tempFormat(input){

    let xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<quiz>\n";

    for(let i = 0; i < input.length; i+=2){
        let question = input[i];
        let answer = input[i + 1];

        xml+= `  <question>\n    ${question}\n  </question>\n  <answer>\n    ${answer}\n  </answer>\n`;

    
    }
    xml+="</quiz>";
    console.log(xml);
}

// 04. Cooking by Numbers
function cooking(arr){
    let number = +arr[0];

    for(let i = 1; i < arr.length; i++){
        let operation = arr[i];
        number = executeOp(number, operation);

        console.log(number);
    }

    function executeOp(num, op){
        switch(op){
            case 'chop': return num / 2;
            case 'dice': return Math.sqrt(num);
            case 'spice': return num + 1;
            case 'bake': return num * 3;
            case 'fillet': return num - (num * 0.2);
        }
    }
}

// 5. Modify Average
function average(input){
    input = String(input);

    let averageSum = 0.0;

    while(averageSum <= 5){
        let tempSum = 0.0;

        for(let i = 0; i < input.length; i++){
            let currentDigit = +input[i];
            tempSum += currentDigit;
        }
        if(tempSum / input.length <= 5){
            input+='9';
        } else{
            averageSum = tempSum;
        }
    }
    console.log(input);
}

// 06. Validity Checker
function checker(arr){
    let x1 = +arr[0];
    let y1 = +arr[1];

    let x2 = +arr[2];
    let y2 = +arr[3];

    let firstDistanceToCenter = Math.sqrt(Math.pow(x1, 2) + Math.pow(y1, 2));
    let secondDistanceToCenter = Math.sqrt(Math.pow(x2, 2) + Math.pow(y2, 2));
    let distanceBetweenPoints = Math.sqrt(Math.pow(x1 - x2, 2) + Math.pow(y1 - y2, 2));

    if(Number.isInteger(firstDistanceToCenter)){
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else{
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    if(Number.isInteger(secondDistanceToCenter)){
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else{
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    if(Number.isInteger(distanceBetweenPoints)){
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else{
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}

// 07. Treasure Locator
function treasure(arr){
    for(let i = 0; i < arr.length; i+=2){
        let x = +arr[i];
        let y = +arr[i + 1];

        if(x >= 8 && x <= 9 && y >= 0 && y <= 1){
            console.log("Tokelau");
        }else if(x >= 1 && x <= 3 && y >= 1 && y <= 3){
            console.log("Tuvalu");
        }else if(x >= 5 && x <= 7 && y >= 3 && y <= 6){
            console.log("Samoa");
        }else if(x >= 0 && x <= 2 && y >= 6 && y <= 8){
            console.log("Tonga");
        }else if(x >= 4 && x <= 9 && y >= 7 && y <= 8){
            console.log("Cook");
        }else{
            console.log("On the bottom of the ocean");
        }
    }
}

// 08. Trip Length
function tripLen(arr){
    let x1 = +arr[0];
    let y1 = +arr[1];

    let x2 = +arr[2];
    let y2 = +arr[3];

    let x3 = +arr[4];
    let y3 = +arr[5];

    let resultArr = [];

    let diff_x_1_2 = x1 - x2;
    let diff_y_1_2 = y1 - y2;

    let diff_x_1_3 = x1 - x3;
    let diff_y_1_3 = y1 - y3;

    let diff_x_2_3 = x2 - x3;
    let diff_y_2_3 = y2 - y3;

    let len_1_2 = Math.sqrt(Math.pow(diff_x_1_2, 2) + Math.pow(diff_y_1_2, 2));
    let len_1_3 = Math.sqrt(Math.pow(diff_x_1_3, 2) + Math.pow(diff_y_1_3, 2));
    let len_2_3 = Math.sqrt(Math.pow(diff_x_2_3, 2) + Math.pow(diff_y_2_3, 2));

    let path_1_2_3 = len_1_2 + len_2_3;
    let path_1_3_2 = len_1_3 + len_2_3;
    let path_2_1_3 = len_1_2 + len_1_3;

    let shortestDistance = Math.min(path_1_2_3, path_1_3_2, path_2_1_3);

    let sum = 0;

    if(shortestDistance == path_1_2_3) {
        console.log(`1->2->3: ${shortestDistance}`);
        return;
    }

    if(shortestDistance == path_1_3_2) {
        console.log(`1->3->2: ${shortestDistance}`);
        return;
    }

    if(shortestDistance == path_2_1_3) {
        console.log(`2->1->3: ${shortestDistance}`);
        return;
    }

}

tripLen([5, 1, 1, 1, 5, 4]);