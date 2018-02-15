function arrJob(input) {
    let arr = [];
    for(let i = 0; i < input.length; i++)
    {
        let currStr = input[i].split(" ");
        let command = currStr[0];
        let number = Number(currStr[1]);
        if(command === "add")
        {
            arr.push(number);
        }
        else if(command === "remove")
        {
            arr.splice(number, 1);
        }
    }
    let result = arr.join("\n");
    console.log(result);
}