let assert = require('chai').assert;
let HolidayPackage = require('./HolidayPackage');

describe("HolidayPackageTests", function () {
    let holidayPackage;
    beforeEach(function () {
        holidayPackage = new HolidayPackage("Sofia", "Summer");
    });
    describe("InitializeTests", function () {
        it("ShouldInitializeVacationersProperly", function () {
            assert.equal(typeof(holidayPackage.vacationers), typeof([]));
            assert.equal(holidayPackage.vacationers.length, 0);
        });
        it("ShouldInitializeDestinationProperly", function () {
            assert.equal(holidayPackage.destination, "Sofia");
        });
        it("ShouldInitializeSeasonProperly", function () {
            assert.equal(holidayPackage.season, "Summer");
        });
        it("ShouldInitializeInsuranceIncludedProperly", function () {
            assert.equal(holidayPackage.insuranceIncluded, false);
        });
        it("ShouldInitializeInsuranceIncludedProperly", function () {
            holidayPackage.insuranceIncluded = true;
            assert.equal(holidayPackage.insuranceIncluded, true);
        });
    });
    describe("ShowVacationersTests", function () {
        it("NoVacationersShouldShowReturnMessage", function () {
           let actual = holidayPackage.showVacationers();
           let expected = "No vacationers are added yet";

           assert.equal(actual, expected);
        });
        it("HasVacationersShouldShowReturnThem", function () {
            holidayPackage.addVacationer("Batman Robinov");
            holidayPackage.addVacationer("Superman Petrov");
            let actual = holidayPackage.showVacationers();

            let expectedVacationers = ["Batman Robinov", "Superman Petrov"];
            let expected = "Vacationers:\n" + expectedVacationers.join("\n");

            assert.equal(actual, expected);
        });
    });
    describe("AddVacationersTests", function () {
        it("AddVacationerInvalidNameNumShouldShowReturnMessage", function () {
            let expected = "Vacationer name must be a non-empty string";

            assert.throws(function () {
                holidayPackage.addVacationer(5)
            }, expected);
        });
        it("AddVacationerInvalidNameShouldShowReturnMessage", function () {
            let expected = "Vacationer name must be a non-empty string";

            assert.throws(function () {
                holidayPackage.addVacationer(" ");
            }, expected);
        });
        it("AddVacationerInvalidEmptyNameShouldShowReturnMessage", function () {
            let expected = "Name must consist of first name and last name";

            assert.throws(function () {
                holidayPackage.addVacationer("")
            }, expected);
        });
        it("AddVacationerInvalidNameShouldShowReturnMessage", function () {
            let expected = "Name must consist of first name and last name";

            assert.throws(function () {
                holidayPackage.addVacationer("Jorko")
            }, expected);
        });
        it("AddVacationerInvalidNameShouldShowReturnMessage", function () {
            let expected = "Name must consist of first name and last name";

            assert.throws(function () {
                holidayPackage.addVacationer("Jorko Jorkov Nevaliden")
            }, expected);
        });
        it("AddVacationerValidNameShouldShowReturnMessage", function () {
            let expected = "Vacationers:" + "\n" + "Jorko Validniq" + "\n" + "Joro Validniq";
            holidayPackage.addVacationer("Jorko Validniq");
            holidayPackage.addVacationer("Joro Validniq");
            let actual = holidayPackage.showVacationers();

            assert.equal(actual, expected);
        });
    });
    
    describe("InsuranceTests", function () {
        it("NonBooleanShouldThrow", function () {
            let expected = "Insurance status must be a boolean";

            assert.throws(function () {
                holidayPackage.insuranceIncluded = "NonBoolean";
            }, expected);
        });
        it("BooleanShouldWorkCorrectly", function () {
            let expected = true;
            holidayPackage.insuranceIncluded = true;
            let actual = holidayPackage.insuranceIncluded;

            assert.equal(actual, expected);
        });
    });
    describe("GenerateHolidayPackage", function () {
       it("NoVacationersShouldThrow", function () {
           let expected = "There must be at least 1 vacationer added";

           assert.throws(function () {
               holidayPackage.generateHolidayPackage();
           }, expected);
       });
        it("ValidShouldWorkCorrectly", function () {
            holidayPackage.season = "Autumn";
            let totalPrice = 800;

            holidayPackage.addVacationer("Mitko Batmanov");
            holidayPackage.addVacationer("Joro Batmanov");

            let expected = "Holiday Package Generated\n" +
                "Destination: " + "Sofia" + "\n" +
                "Vacationers:" + "\n" + ["Mitko Batmanov" + "\n" + "Joro Batmanov"] + "\n" +
                "Price: " + totalPrice;

            let actual = holidayPackage.generateHolidayPackage();

            assert.equal(actual, expected);
        });

        it("ValidWithAllBonusesShouldWorkCorrectly", function () {
            let totalPrice = 1100;
            holidayPackage.addVacationer("Mitko Batmanov");
            holidayPackage.addVacationer("Joro Batmanov");

            let expected = "Holiday Package Generated\n" +
                "Destination: " + "Sofia" + "\n" +
                "Vacationers:" + "\n" + ["Mitko Batmanov" + "\n" + "Joro Batmanov"] + "\n" +
                "Price: " + totalPrice;

            holidayPackage.insuranceIncluded = true;
            let actual = holidayPackage.generateHolidayPackage();

            assert.equal(actual, expected);
        });
        it("ValidWithSeasonBonusBonusesShouldWorkCorrectly", function () {
            let totalPrice = 600;
            holidayPackage.addVacationer("Mitko Batmanov");

            let expected = "Holiday Package Generated\n" +
                "Destination: " + "Sofia" + "\n" +
                "Vacationers:" + "\n" + ["Mitko Batmanov"] + "\n" +
                "Price: " + totalPrice;

            let actual = holidayPackage.generateHolidayPackage();

            assert.equal(actual, expected);
        });
        it("ValidWithInsuranceBonusesShouldWorkCorrectly", function () {
            let totalPrice = 500;
            holidayPackage.season = "Autumn";
            holidayPackage.addVacationer("Mitko Batmanov");

            let expected = "Holiday Package Generated\n" +
                "Destination: " + "Sofia" + "\n" +
                "Vacationers:" + "\n" + "Mitko Batmanov" + "\n" +
                "Price: " + totalPrice;

            holidayPackage.insuranceIncluded = true;
            let actual = holidayPackage.generateHolidayPackage();

            assert.equal(actual, expected);
        });
    });
});

//expect(()=>holidayPackage.addVacationer(1)).to.throw();