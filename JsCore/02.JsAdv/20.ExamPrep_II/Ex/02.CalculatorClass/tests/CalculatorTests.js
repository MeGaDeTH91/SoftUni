let assert = require('chai').assert;
let Calculator = require('../Calculator');

describe("CalculatorTests", function () {
    let ourCalculator;
   beforeEach(function () {
       ourCalculator = new Calculator();
   });
   it("ShouldInitializeProperly", function () {
       let actual = typeof(ourCalculator.expenses);
       let expected = typeof([]);
       assert.equal(actual, expected);
   });
   it("ShouldInitializeProperLength", function () {
       let actual = ourCalculator.expenses.length;
       let expected = 0;
       assert.equal(actual, expected);
   });
   it("ShouldAddDataCorrectly", function () {
      ourCalculator.add("Pepi");
      ourCalculator.add(5);

      let actualItem1 = ourCalculator.expenses[0];
      let actualItem2 = ourCalculator.expenses[1];
      assert.equal(actualItem1, "Pepi");
      assert.equal(actualItem2, 5);
   });
   describe("DivideTests", function () {
       it("DivideWithZeroShouldReturnErrorMessage", function () {
           ourCalculator.add("Pepi");
           ourCalculator.add(5);
           ourCalculator.add("Donkey");
           ourCalculator.add(0);
           ourCalculator.add(4);

           let actual = ourCalculator.divideNums();
           let expected = "Cannot divide by zero";
           assert.equal(actual, expected);
       });
       it("DivideWithZeroShouldReturnErrorMessage", function () {
           ourCalculator.add("Pepi");
           ourCalculator.add("");
           ourCalculator.add("Donkey");
           ourCalculator.add("NaN");
           ourCalculator.add("NoNumsHere");

           let expected = "There are no numbers in the array!";
           assert.throws(function () {
               ourCalculator.divideNums()
           }, expected);
       });
       it("DivideWithZeroShouldReturnErrorMessage", function () {
           ourCalculator.add("Pepi");
           ourCalculator.add(20);
           ourCalculator.add("Donkey");
           ourCalculator.add(5);
           ourCalculator.add(2);

           let actual = ourCalculator.divideNums();
           let expected = 2;
           assert.equal(actual, expected);
       });
   });
   describe("ToStringTests", function () {
      it("EmptyArrShouldReturnMessage", function () {
          let actual = ourCalculator.toString();
          let expected = 'empty array';

          assert.equal(actual, expected);
      });
       it("EmptyArrShouldReturnMessage", function () {
           ourCalculator.add("Pepi");
           ourCalculator.add(20);
           ourCalculator.add("Donkey");
           ourCalculator.add(5);
           ourCalculator.add(2);

           let actual = ourCalculator.toString();
           let expected = "Pepi -> 20 -> Donkey -> 5 -> 2";

           assert.equal(actual, expected);
       });
   });
   describe("OrderTests", function () {
      it("EmptyShouldReturnMessage", function () {
          let actual = ourCalculator.orderBy();
          let expected = "empty";

          assert.equal(actual, expected);
      });
       it("NumberOrderShouldWorkCorrectly", function () {
           ourCalculator.add(20);
           ourCalculator.add(5);
           ourCalculator.add(2);

           let actual = ourCalculator.orderBy();
           let expected = "2, 5, 20";

           assert.equal(actual, expected);
       });
       it("NumberOrderShouldWorkCorrectly", function () {
           ourCalculator.add("Qna");
           ourCalculator.add("Todor");
           ourCalculator.add("Asen");

           let actual = ourCalculator.orderBy();
           let expected = "Asen, Qna, Todor";

           assert.equal(actual, expected);
       });
   });
});