let {carService} = require("../03. Car Service");
let {assert} = require("chai");

describe("Test isItExpensive function", () =>{

    it("should return correct message if the input is Engine or Transmission", () => {
        assert.equal(carService.isItExpensive('Engine'), 'The issue with the car is more severe and it will cost more money');
        assert.equal(carService.isItExpensive('Transmission'), 'The issue with the car is more severe and it will cost more money');
    })

    it("should return correct message if the input is not Engine or Transmission", () => {
        assert.equal(carService.isItExpensive('Wheel'), 'The overall price will be a bit cheaper');
        assert.equal(carService.isItExpensive('Hood'), 'The overall price will be a bit cheaper');
    })
})

describe("Test discount function", () =>{

    it("should return throw error if the input is not in the correct format", () => {
        assert.throw(() => carService.discount('5', '1250'), "Invalid input");
        assert.throw(() => carService.discount('test', 50), "Invalid input");
        assert.throw(() => carService.discount(7, 'test'), "Invalid input");
    })

    it("should return correct discount percentage result", () => {
        assert.equal(carService.discount(5, 50), 'Discount applied! You saved 7.5$');
        assert.equal(carService.discount(9, 8.2), 'Discount applied! You saved 2.4599999999999995$');
    })

    it("should return correct message if the number parts is equal to 2", () => {
        assert.equal(carService.discount(2, 50), 'You cannot apply a discount');
        assert.equal(carService.discount(1, 100), "You cannot apply a discount");
    })
})

describe("Test partsToBuy function", () =>{

    it("should return throw error if the input is not an array", () => {
        assert.throw(() => carService.partsToBuy(2, 3), "Invalid input");
        assert.throw(() => carService.partsToBuy('test', 'test'), "Invalid input");
        assert.throw(() => carService.partsToBuy(2, 'array'), "Invalid input");
    })

    it("should return correct result", () => {
        assert.equal(carService.partsToBuy([{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 }], ["blowoff valve", "injectors"]), 145);
        assert.equal(carService.partsToBuy([{ part: "turbo", price: 250 }, { part: "intercooler", price: 150 }], ["turbo", "intercooler"]), 400);
        assert.equal(carService.partsToBuy([], ["turbo", "spoiler"]), 0);
    })
})