// 01. Print Array with Given Delimiter
function arrDel(arr){
    let delimiter = arr[arr.length - 1];

    let resultArr = arr.slice(0, arr.length - 1);
    console.log(resultArr.join(delimiter));
}

// 02. Print every N-th Element from an Array
function printNth(arr){
    let step = +arr[arr.length - 1];

    let resultArr = arr.slice(0, arr.length - 1);

    resultArr = resultArr.map((item, index) =>{
        if(index % step === 0){
            return item;
        }
    })
    .filter((item) => {
        return item != undefined;
    });

    console.log(resultArr.join("\n"));
}

// 03. Add and Remove Elements
function addOrRemove(arr){
    let number = 1;

    let resultArr = [];

    arr.forEach((item) => {
        if(item === 'add'){
            resultArr.push(number++);
        } else if (item === 'remove'){
            resultArr.pop();
            number++;
        }
    });

    if(resultArr.length === 0){
        console.log("Empty")
    } else{
        console.log(resultArr.join("\n"))
    }
}

// 04. Rotate Array
function rotateArr(arr){
    let resultArr = arr.slice(0, arr.length - 1);

    let rotations = +arr[arr.length - 1] % resultArr.length;

    for(let i = 1; i <= rotations; i++){
        let element = resultArr.pop();

        resultArr.unshift(element);
    }

    console.log(resultArr.join(" "));
}

// 05. Extract Increasing Subsequence from Array
function incrSub(arr){
    let currentBiggest = 0;

    let resultArr = [];

    arr.forEach(num => {
        let element = +num;

        if(element >= currentBiggest){
            currentBiggest = element;
            resultArr.push(element);
        } 
    })

    console.log(resultArr.join("\n"))
}

// 06. Sort Array 
function sortBy2(arr){
    arr.sort((a, b) => {
        let comparison = a.length - b.length;

        if(comparison === 0){
            return a > b;
        }
        return comparison;
    });

    console.log(arr.join("\n"));
}

// 07. Magic Matrices
function matrices(matrix){
    let sum = +matrix[0].reduce((acc, current) => {
        return acc += +current;
    }, 0);

    let matrixSize = matrix.length;

    for (let col = 0; col < matrixSize; col++) {
        let innerSum = 0;
        for(let row = 0; row < matrixSize; row++){
            innerSum += +matrix[row][col];
        }
        if(innerSum != sum){
            return false;
        }
    }
    return true;
}

// 08. Spiral Matrix
function spiral(rowCount, colCount){
    let lastNumber = rowCount * colCount;

    let matrix = [];

    for(let i=0; i<rowCount; i++) {
        matrix.push([]);
    }

    let startRow = 0;
    let startCol = 0;

    let endRow = rowCount - 1;
    let endCol = colCount - 1;

    let currentNumber = 1;

    while(startRow<=endRow || startCol<=endCol){
        for (let col = startCol; col <= endCol; col++) {
            matrix[startRow][col] = currentNumber++;
        }
    
        for (let row = startRow + 1; row <= endRow; row++) {
            matrix[row][endCol] = currentNumber++;
        }
    
        for (let col = endCol - 1; col >= startCol; col--) {
            matrix[endRow][col] = currentNumber++;
        }
    
        for (let row = endRow - 1; row > startRow; row--) {
            matrix[row][startCol] = currentNumber++;
        }
        
        startRow++;
        startCol++;
        endRow--;
        endCol--;
    }

    console.log(matrix.map(x => x.join(" ")).join("\n"));
}

// 09. Diagonal Attack
function diagonal(input){
    let primaryDiagonal = 0;
    let secondaryDiagonal = 0;
    
    let matrix = input.map(row => row.split(' ').map(num => +num));

    for (let row = 0; row < matrix.length; row++) {
        primaryDiagonal += matrix[row][row];
        secondaryDiagonal += matrix[row][matrix.length - 1 - row]
    }

    if(primaryDiagonal === secondaryDiagonal){
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix[row].length; col++) {
                if(row != col && col != matrix[row].length - 1 - row){
                    matrix[row][col] = primaryDiagonal;
                }                
            }
            
        }
    }

    console.log(matrix.map(x => x.join(" ")).join("\n"));
}

// 10. Orbit
function orbit(arr){
    let colsCount = +arr[0];
    let rowsCount = +arr[1];

    matrix = [];
    for (let row = 0; row < rowsCount; row++) {
        matrix.push([]);   
    }
    let x = +arr[2];
    let y = +arr[3];

    matrix[x][y] = 1;

    for (let row = 0; row < rowsCount; row++) {
        for (let col = 0; col < colsCount; col++) {
            matrix[row][col] = Math.max(Math.abs(x - row),Math.abs(y - col)) + 1;
        }     
    }

    console.log(matrix.map(x => x.join(" ")).join("\n"))
}