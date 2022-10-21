let {bookSelection} = require("../bookSelection");
let {assert} = require("chai");

describe("Test isGenreSuitable function", () =>{

    it("should return the correct message if the genre is not suitable for the age", () => {
        assert.equal(bookSelection.isGenreSuitable('Thriller', 12), `Books with Thriller genre are not suitable for kids at 12 age`);
        assert.equal(bookSelection.isGenreSuitable('Horror', 11), `Books with Horror genre are not suitable for kids at 11 age`);
        assert.equal(bookSelection.isGenreSuitable('Horror', 7), `Books with Horror genre are not suitable for kids at 7 age`);

    })

    it("should return the correct message if the genre is suitable for age", () => {
        assert.equal(bookSelection.isGenreSuitable('Comedy', 7), `Those books are suitable`);
        assert.equal(bookSelection.isGenreSuitable('Action', 9), `Those books are suitable`);
        assert.equal(bookSelection.isGenreSuitable('Cartoons', 5), `Those books are suitable`);
    })
})

describe("Test isItAffordable function", () =>{

    it("should return the correct message if the input is not in the correct format", () => {
        assert.throw(() => bookSelection.isItAffordable('test', 'test'), "Invalid input");
        assert.throw(() => bookSelection.isItAffordable(5, 'test'), "Invalid input");
        assert.throw(() => bookSelection.isItAffordable('test', 1.0), "Invalid input");
        assert.throw(() => bookSelection.isItAffordable(1.0, 1.0), "Invalid input");
    })

    it("should return the correct message if input is in in the correct format", () => {
        assert.equal(bookSelection.isItAffordable(5, 10), `Book bought. You have 5$ left`);
        assert.equal(bookSelection.isItAffordable(5.79, 10.50), `Book bought. You have 4.71$ left`);
    })

    it('should return the correct message if you do not have enough money', () => {
        assert.equal(bookSelection.isItAffordable(8, -1), `You don't have enough money`);
        assert.equal(bookSelection.isItAffordable(1, -1), `You don't have enough money`);
        assert.equal(bookSelection.isItAffordable(1, 0), `You don't have enough money`);
    })
})

describe("Test suitableTitles function", () =>{

    it("should return the correct message if the input is not an array", () => {
        assert.throw(() => bookSelection.suitableTitles('test', {}), "Invalid input");
        assert.throw(() => bookSelection.suitableTitles(5, 1.0), "Invalid input");
        assert.throw(() => bookSelection.suitableTitles('test', 10), "Invalid input");
    })

    it("should return the correct message if the input is an array", () => {
        assert.equal(bookSelection.suitableTitles([{ title: "The Da Vinci Code", genre: "Science" }], 'Science'), "The Da Vinci Code");
        assert.equal(bookSelection.suitableTitles([{ title: "The House", genre: "Horror" }], 'Horror'), "The House");
        assert.equal(bookSelection.suitableTitles([{ title: "The House", genre: "Horror" }, { title: "The Bank", genre: "Criminal" }, { title: "Perfect Code", genre: "Science" }], 'Criminal'), "The Bank");
    })
})