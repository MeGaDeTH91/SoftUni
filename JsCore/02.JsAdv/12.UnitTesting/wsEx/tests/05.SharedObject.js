let assert = require('chai').assert;
let expect = require('chai').expect;
let jsdom = require('jsdom-global')();
let $ = require("jquery");

document.body.innerHTML = `<div id="wrapper">
        <input type="text" id="name">
        <input type="text" id="income">
    </div>`;

let sharedObject = require("../shared-object").sharedObject;

describe("SharedObjectAllTests", function () {
    beforeEach("Initialize HTML", function () {
        document.body.innerHTML =
            `<div id="wrapper">
                <input type="text" id="name">
                <input type="text" id="income">
            </div>`;
    });
    before(()=>global.$ = $);

    describe("sharedObjectInitialTests", function () {

        it("checkInitialNameShouldBeNull", function () {
            let actual = sharedObject.name;
            let expected = null;
            assert.equal(actual, expected);
        });
        it("checkInitialIncomeShouldBeNull", function () {
            let actual = sharedObject.income;
            let expected = null;
            assert.equal(actual, expected);
        });
    });
    describe("NameTests", function () {
        it("changeNameInvalidShouldRemainNull", function () {
            sharedObject.changeName("");
            let actual = sharedObject.name;
            let expected = null;
            assert.equal(actual, expected);
        });
        it("changeNameValidShouldWorkCorrectly", function () {
            sharedObject.changeName("Ingvi");
            let actual = sharedObject.name;
            let expected = "Ingvi";
            assert.equal(actual, expected);
        });
        it("changeNameJqValidShouldWorkCorrectly", function () {
            sharedObject.changeName("Ingvi");
            let actual = $('#name').val();
            let expected = "Ingvi";
            assert.equal(actual, expected);
        });
        it("changeNameNumberValidShouldWorkCorrectly", function () {
            sharedObject.changeName(55);
            let actual = sharedObject.name;
            let expected = 55;
            assert.equal(actual, expected);
        });
        it("changeNameNumberValidShouldWorkCorrectly", function () {
            sharedObject.changeName(55);
            let actual = $('#name').val();
            let expected = "55";
            assert.equal(actual, expected);
        });

    });

    describe("IncomeTests", function () {
        it("changeIncomeInvalidShouldReturnEmptyStr", function () {
            sharedObject.changeIncome("asl");
            let actual = sharedObject.income;
            let expected = null;
            assert.equal(actual, expected);
        });
        it("changeNegativeIncomeInvalidShouldReturnEmptyStr", function () {
            sharedObject.changeIncome(-5);
            let actual = sharedObject.income;
            let expected = null;
            assert.equal(actual, expected);
        });
        it("changeZeroIncomeInvalidShouldReturnEmptyStr", function () {
            sharedObject.changeIncome(0);
            let actual = sharedObject.income;
            let expected = null;
            assert.equal(actual, expected);
        });
        it("changeZeroIncomeInvalidShouldReturnEmptyStr", function () {
            sharedObject.changeIncome(2.5);
            let actual = sharedObject.income;
            let expected = null;
            assert.equal(actual, expected);
        });
        it("changeIncomeValidShouldWorkCorrectly", function () {
            sharedObject.changeIncome(26);
            let actual = ($("#income").val());
            let expected = 26;
            assert.equal(actual, expected);
        });
        it("changeIncomeValidShouldWorkCorrectly", function () {
            sharedObject.changeIncome(246);
            let actual = sharedObject.income;
            let expected = 246;
            assert.equal(actual, expected);
        });
    });

    describe("UpdateNameTests", function () {
        it("UpdateNameInvalidShouldRemainNull", function () {
            sharedObject.changeName("Pepkata");
            $('#name').val('');
            sharedObject.updateName();
            let actual = sharedObject.name;
            let expected = "Pepkata";
            assert.equal(actual, expected);
        });
        it("UpdateNameValidShouldWorkCorrectly", function () {
            sharedObject.changeName("Pepkata");
            $('#name').val(15);
            sharedObject.updateName();
            let actual = sharedObject.name;
            let expected = "15";
            assert.equal(actual, expected);
        });
        it("UpdateNameValidShouldWorkCorrectly", function () {
            sharedObject.changeName("Pepkata");
            $('#name').val('Goshkata');
            sharedObject.updateName();
            let actual = sharedObject.name;
            let expected = "Goshkata";
            assert.equal(actual, expected);
        });
    });
    describe("UpdateIncomeTests", function () {
        it("InvalidIncomeShouldReturnNothing", function () {
            sharedObject.changeIncome(26);
            $('#income').val(NaN);
            sharedObject.updateIncome();
            let actual = sharedObject.income;
            let expected = 26;
            assert.equal(actual, expected);
        });
        it("InvalidIncomeShouldReturnNothing", function () {
            sharedObject.changeIncome(26);
            $('#income').val(2.5);
            sharedObject.updateIncome();
            let actual = sharedObject.income;
            let expected = 26;
            assert.equal(actual, expected);
        });
        it("InvalidIncomeShouldReturnNothing", function () {
            sharedObject.changeIncome(26);
            $('#income').val(0);
            sharedObject.updateIncome();
            let actual = sharedObject.income;
            let expected = 26;
            assert.equal(actual, expected);
        });
        it("InvalidIncomeShouldReturnNothing", function () {
            sharedObject.changeIncome(26);
            $('#income').val(-50);
            sharedObject.updateIncome();
            let actual = sharedObject.income;
            let expected = 26;
            assert.equal(actual, expected);
        });
        it("UpdateIncomeValidShouldWorkCorrectly", function () {
            sharedObject.changeIncome(5);
            $('#income').val(10);
            sharedObject.updateIncome();
            let actual = sharedObject.income;
            let expected = 10;
            assert.equal(actual, expected);
        });
    })
});