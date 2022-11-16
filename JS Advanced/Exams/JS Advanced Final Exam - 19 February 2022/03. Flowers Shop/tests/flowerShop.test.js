let {flowerShop} = require("../flowerShop");
let {assert} = require("chai");

describe("Test calcPriceOfFlowers function", () =>{

    it("should throw error if the input is not in the correct format", () => {
        assert.throw(() => flowerShop.calcPriceOfFlowers(1, '17.3', '21.21'), "Invalid input!");
        assert.throw(() => flowerShop.calcPriceOfFlowers('test', '17.3', [21, 32]), "Invalid input!");
        assert.throw(() => flowerShop.calcPriceOfFlowers(1, 12, 54), "Invalid input!");
        assert.throw(() => flowerShop.calcPriceOfFlowers(1, '17.3', 54), "Invalid input!");
        assert.throw(() => flowerShop.calcPriceOfFlowers(1, {}, 54), "Invalid input!");
    })

    it("should return the result", () => {
        assert.equal(flowerShop.calcPriceOfFlowers('Rose', 10, 2), 'You need $20.00 to buy Rose!');
        assert.equal(flowerShop.calcPriceOfFlowers('Rose', 7, 101), 'You need $707.00 to buy Rose!');
        assert.equal(flowerShop.calcPriceOfFlowers('Rose', 8, 5), 'You need $40.00 to buy Rose!');
    })
})

describe("Test checkFlowersAvailable function", () =>{

    it("should return searched flower", () => {
        assert.equal(flowerShop.checkFlowersAvailable("Rose", ["Rose", "Lily", "Orchid"]), 'The Rose are available!');
        assert.equal(flowerShop.checkFlowersAvailable("Lily", ["Rose", "Lily", "Orchid"]), 'The Lily are available!');
        assert.equal(flowerShop.checkFlowersAvailable("Orchid", ["Rose", "Lily", "Orchid"]), 'The Orchid are available!');
    })

    it("should return searched flower", () => {
        assert.equal(flowerShop.checkFlowersAvailable("Rose", ["Lily", "Orchid"]), 'The Rose are sold! You need to purchase more!');
        assert.equal(flowerShop.checkFlowersAvailable("Lily", ["Rose", "Orchid"]), 'The Lily are sold! You need to purchase more!');
        assert.equal(flowerShop.checkFlowersAvailable("Orchid", ["Rose", "Lily"]), 'The Orchid are sold! You need to purchase more!');
    })
})

describe("Test sellFlowers function", () =>{

    it("should throw error if the input is not in the correct type", () => {
        assert.throw(() => flowerShop.sellFlowers('tets', 'tets'), "Invalid input!");
        assert.throw(() => flowerShop.sellFlowers('tets', -1), "Invalid input!");
        assert.throw(() => flowerShop.sellFlowers(["Lily", "Orchid"], 3), "Invalid input!");
        assert.throw(() => flowerShop.sellFlowers({}, '6'), "Invalid input!");
    })

    it("should return the right result", () => {
        assert.equal(flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 1), "Rose / Orchid");
        assert.equal(flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 2), "Rose / Lily");
        assert.equal(flowerShop.sellFlowers(["Rose", "Lily", "Orchid", "Water Lily"], 3), "Rose / Lily / Orchid");
    })
})