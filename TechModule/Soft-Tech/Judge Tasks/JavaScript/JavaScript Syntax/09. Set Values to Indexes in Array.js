function array(arr) {
    let n = Number(arr[0]);
    let result = [];
    for(let j=0; j < n; j++)
    {
        for(let i = 0; i < n; i++)
        {
            result[i] = 0;
        }
    }
    for(let i = 1; i < arr.length; i++)
    {
        let currStr = arr[i].split(' - ');
        let index = Number(currStr[0]);
        let element = Number(currStr[1]);
        result[index] = element;
    }
    console.log(result.join("\n"))
}