let { movieTheater } = require("../03. Movie Theater");
let { assert } = require("chai");

describe("Test ageRestrictions function", () => {

    it("should return the right messages for current restrictions", () => {
        assert.equal(movieTheater.ageRestrictions('G'), 'All ages admitted to watch the movie');
        assert.equal(movieTheater.ageRestrictions('PG'), 'Parental guidance suggested! Some material may not be suitable for pre-teenagers');
        assert.equal(movieTheater.ageRestrictions('R'), 'Restricted! Under 17 requires accompanying parent or adult guardian');
        assert.equal(movieTheater.ageRestrictions('NC-17'), 'No one under 17 admitted to watch the movie');
        assert.equal(movieTheater.ageRestrictions(''), 'There are no age restrictions for this movie');
    })
})

describe("Test moneySpent function", () => {

    it("should return invalid input if the inputs are not in the correct format", () => {
        assert.throw(() => movieTheater.moneySpent('', {}, {}), "Invalid input");
        assert.throw(() => movieTheater.moneySpent(1, "sdfadf", ["Soda", "Water"]), "Invalid input");
        assert.throw(() => movieTheater.moneySpent(["adsf"], ["Popcorn"], ["Soda", "Water"]), "Invalid input");
    })

    it("should return the total cost without a discount", () => {
        assert.equal(movieTheater.moneySpent(2, ['Nachos', 'Popcorn'], ['Soda', 'Water']), 'The total cost for the purchase is 44.50');
        assert.equal(movieTheater.moneySpent(1, ['Popcorn'], ['Soda']), 'The total cost for the purchase is 22.00');

    })

    it("should return the total cost with a discount", () => {
        assert.equal(movieTheater.moneySpent(3, ['Nachos', 'Popcorn', 'Popcorn'], ['Soda', 'Water', 'Soda']), 'The total cost for the purchase with applied discount is 53.20');
        assert.equal(movieTheater.moneySpent(5, ['Nachos', 'Popcorn', 'Popcorn', 'Nachos', 'Nachos'], ['Soda', 'Water', 'Soda', 'Soda', 'Soda']), 'The total cost for the purchase with applied discount is 90.80');
    })

})

describe("Test reservation function", () => {

    it("should return invalid input if the input's type is not in the correct format", () => {
        assert.throw(() => movieTheater.reservation([{ rowNumber: 1, freeSeats: 2 }], ''), "Invalid input");
        assert.throw(() => movieTheater.moneySpent(1, "sdfadf"), "Invalid input");
        assert.throw(() => movieTheater.moneySpent(["adsf"], 7), "Invalid input");
        assert.throw(() => movieTheater.moneySpent(["adsf"], 7), "Invalid input");

    })

    it("should return the row with the largest number", () => {
        assert.equal(movieTheater.reservation([
            { rowNumber: 1, freeSeats: 2 },
            { rowNumber: 2, freeSeats: 2 },
        ], 1), 2);

        assert.equal(movieTheater.reservation([
            { rowNumber: 1, freeSeats: 5 },
            { rowNumber: 2, freeSeats: 3 },
        ], 2), 2);
    })
})