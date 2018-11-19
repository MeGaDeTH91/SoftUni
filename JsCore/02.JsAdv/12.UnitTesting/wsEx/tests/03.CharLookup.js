let assert = require("chai").assert;

function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

describe("charLookupTests", function () {
    it("invalidStringShouldReturnUndefined", function () {
        let actual = lookupChar(13, 0);
        let expected = undefined;

        assert.equal(actual, expected);
    });
    it("invalidIndexShouldReturnUndefined", function () {
        let actual = lookupChar("test", "asd");
        let expected = undefined;

        assert.equal(actual, expected);
    });
    it("floatingIndexShouldReturnUndefined", function () {
        let actual = lookupChar("test", 2.5);
        let expected = undefined;

        assert.equal(actual, expected);
    });
    it("largerIndexShouldReturnErrorMsg", function () {
        let actual = lookupChar("test", 4);
        let expected = "Incorrect index";

        assert.equal(actual, expected);
    });
    it("smallerIndexShouldReturnErrorMsg", function () {
        let actual = lookupChar("test", -1);
        let expected = "Incorrect index";

        assert.equal(actual, expected);
    });
    it("validIndexShouldWorkCorrectly", function () {
        let actual = lookupChar("test", 1);
        let expected = "e";

        assert.equal(actual, expected);
    });
});
