let {rentCar} = require("../03. Rent Car");
let {assert} = require("chai");

describe("Test searchCar function", () =>{

    it("should throw an error if the input is not in the correct format", () => {
        assert.throw(() => rentCar.searchCar({}, 'test'), "Invalid input!");
        assert.throw(() => rentCar.searchCar([], 34), "Invalid input!");
        assert.throw(() => rentCar.searchCar('test', 'test'), "Invalid input!");
    })

    it("should throw an error if there are no such models in the catalog", () => {
        assert.throw(() => rentCar.searchCar(['Audi A3', 'Mercedes C63'], 'BMW M5'), "There are no such models in the catalog!");
        assert.throw(() => rentCar.searchCar(['Audi A3', 'Mercedes C63', 'Ferrari SF90'], 'Mercedes AMG 2020'), "There are no such models in the catalog!");
    })

    it("should return the error right message if there is such car in the catalogue", () => {
        assert.equal(rentCar.searchCar(['Audi A3', 'Mercedes C63', 'Ferrari SF90'], 'Ferrari SF90'), "There is 1 car of model Ferrari SF90 in the catalog!");
        assert.equal(rentCar.searchCar(['Audi A3', 'Mercedes C63', 'Ferrari SF90', 'Mercedes AMG 2020', 'Mercedes AMG 2020', 'Mercedes AMG 2020'], 'Mercedes AMG 2020'), "There is 3 car of model Mercedes AMG 2020 in the catalog!");
        assert.equal(rentCar.searchCar(['Audi A3', 'Mercedes C63', 'Ferrari SF90', 'Porshe GT 3', 'Porshe GT 3'], 'Porshe GT 3'), "There is 2 car of model Porshe GT 3 in the catalog!");
    })
})

describe("Test calculatePriceOfCar function", () =>{

    it("should throw an error if the input is not in the correct format", () => {
        assert.throw(() => rentCar.calculatePriceOfCar(34, 'test'), "Invalid input!");
        assert.throw(() => rentCar.calculatePriceOfCar([], 'test'), "Invalid input!");
        assert.throw(() => rentCar.calculatePriceOfCar('test', 'test'), "Invalid input!");
        assert.throw(() => rentCar.calculatePriceOfCar([], {}), "Invalid input!");
    })

    it("should throw an error if there are no such models in the catalog", () => {
        assert.throw(() => rentCar.calculatePriceOfCar("McLaren 720S", 41), "No such model in the catalog!");
        assert.throw(() => rentCar.calculatePriceOfCar("Ferrari La", 50), "No such model in the catalog!");
        assert.throw(() => rentCar.calculatePriceOfCar("Lamborghini Huracan", 34), "No such model in the catalog!");
    })

    it("should return the error right message if there is a car in the catalogue", () => {
        assert.equal(rentCar.calculatePriceOfCar('Mercedes', 50), "You choose Mercedes and it will cost $2500!");
        assert.equal(rentCar.calculatePriceOfCar('Audi', 36), "You choose Audi and it will cost $1296!");
        assert.equal(rentCar.calculatePriceOfCar('BMW', 45), "You choose BMW and it will cost $2025!");
    })
})

describe("Test checkBudget function", () =>{

    it("should throw an error if the input is not in the correct format(int)", () => {
        assert.throw(() => rentCar.checkBudget('5','43', 56), "Invalid input!");
        assert.throw(() => rentCar.checkBudget([43, 54, 4],'43', 34.54), "Invalid input!");
        assert.throw(() => rentCar.checkBudget(45,'', {}), "Invalid input!");
    })

    it("should return the right message if there is enough money to rent a car", () => {
        assert.equal(rentCar.checkBudget(15, 20, 500), "You rent a car!");
        assert.equal(rentCar.checkBudget(32, 3, 400), "You rent a car!");
        assert.equal(rentCar.checkBudget(8, 45, 1000), "You rent a car!");
    })

    it("should return the right message if there is enough money to rent a car", () => {
        assert.equal(rentCar.checkBudget(383, 47, 100), "You need a bigger budget!");
        assert.equal(rentCar.checkBudget(78, 3, 34), "You need a bigger budget!");
        assert.equal(rentCar.checkBudget(100, 45, 3), "You need a bigger budget!");
    })
})