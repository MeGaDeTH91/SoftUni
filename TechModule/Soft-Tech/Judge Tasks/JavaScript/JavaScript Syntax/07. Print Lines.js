function lines(arr) {
    let result = [];
    let printer = "";
    for(let i=0; i < arr.length; i++)
    {
        let current = arr[i];
        if(current === "Stop")
        {
            printer = result.join("\n");
            console.log(printer);
            return;
        }
        else
        {
            result.push(arr[i]);
        }

    }
}