let assert = require('chai').assert;

let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};

describe("MathEnforcesTests", function () {
    it("addInvalidNumberShouldReturnUndefined", function () {
        let actual = mathEnforcer.addFive("invalidNum");
        let expected = undefined;

        assert.equal(actual, expected);
    });
    it("addValidNumberShouldWorkCorrectly", function () {
        let actual = mathEnforcer.addFive(5);
        let expected = 10;

        assert.equal(actual, expected);
    });
    it("addValidNumberShouldWorkCorrectly", function () {
        let actual = mathEnforcer.addFive(5.25);
        let expected = 10.25;

        assert.equal(actual, expected);
    });
    it("addValidNegNumberShouldWorkCorrectly", function () {
        let actual = mathEnforcer.addFive(-15);
        let expected = -10;

        assert.equal(actual, expected);
    });
    it("subtractInvalidNumberShouldReturnUndefined", function () {
        let actual = mathEnforcer.subtractTen("invalidNum");
        let expected = undefined;

        assert.equal(actual, expected);
    });
    it("subtractValidNumberShouldWorkCorrectly", function () {
        let actual = mathEnforcer.subtractTen(15);
        let expected = 5;

        assert.equal(actual, expected);
    });
    it("subtractValidNegNumberShouldWorkCorrectly", function () {
        let actual = mathEnforcer.subtractTen(-15);
        let expected = -25;

        assert.equal(actual, expected);
    });
    it("subtractValidNegNumberShouldWorkCorrectly", function () {
        let actual = mathEnforcer.subtractTen(-15.7);
        let expected = -25.7;

        assert.equal(actual, expected);
    });
    it("sumInvalidNumberAShouldReturnUndefined", function () {
        let actual = mathEnforcer.sum("invalidNum", 5);
        let expected = undefined;

        assert.equal(actual, expected);
    });
    it("sumInvalidNumberBShouldReturnUndefined", function () {
        let actual = mathEnforcer.sum(5, "invalidNum");
        let expected = undefined;

        assert.equal(actual, expected);
    });
    it("sumValidNumbersShouldReturnUndefined", function () {
        let actual = mathEnforcer.sum(6, 20);
        let expected = 26;

        assert.equal(actual, expected);
    });
    it("sumValidNumbersShouldReturnUndefined", function () {
        let actual = mathEnforcer.sum(5.5, 10.5);
        let expected = 16;

        assert.equal(actual, expected);
    });
});