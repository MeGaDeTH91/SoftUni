function multiplyNums(nums) {
    let n = Number(nums[0]);
    let x = Number(nums[1]);
    let result = 0;
    if(x >= n){
        result = x * n;
    }
    else
    {
        result = n / x;
    }
    return result;
}