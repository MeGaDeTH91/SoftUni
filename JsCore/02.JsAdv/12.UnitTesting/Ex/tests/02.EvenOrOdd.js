function isOddOrEven(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }
    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

describe("checkOddOrEven", function(){
    it("shouldReturnUndefined", function(){
        let actual = isOddOrEven(5);
        let expected = undefined;

        assert.equal(actual, expected);
    })
    it("shouldReturnEven", function(){
        let actual = isOddOrEven("even");
        let expected = "even";

        assert.equal(actual, expected);
    })
    it("shouldReturnOdd", function(){
        let actual = isOddOrEven("odd");
        let expected = "odd";

        assert.equal(actual, expected);
    })
})