class CarDealership {
    constructor (name) {
        this.name = name;
        this.availableCars = [];
        this.soldCars = [];
        this.totalIncome = 0; 
    }

    addCar (model, horsepower, price, mileage) {
        if (model == '' || horsepower < 0 || price < 0 || mileage < 0) {
            throw new Error("Invalid input!");
        }

        this.availableCars.push({model, horsepower, price, mileage});

        return `New car added: ${model} - ${horsepower} HP - ${mileage.toFixed(2)} km - ${price.toFixed(2)}$`
    } 

    sellCar(model, desiredMileage) {
        let searchedCar = this.availableCars.find(car => car.model === model);

        if (!searchedCar) {
            throw new Error(`${model} was not found!`);
        }

        let carMileage = searchedCar.mileage
        let soldPrice = 0;
        let difference = carMileage - desiredMileage;

        if (carMileage <= desiredMileage) {
            soldPrice = searchedCar.price
        }
        else if (difference <= 40000) {
            //the price gets deducted by 5%!
            soldPrice = searchedCar.price * 0.95;
        }
        else {
            //the price gets deducted by 10%!
            soldPrice = searchedCar.price * 0.9;
        }

        this.availableCars.pop(searchedCar);

        this.soldCars.push({
            model: searchedCar.model,
            horsepower: searchedCar.horsepower,
            soldPrice
        });

        this.totalIncome += soldPrice;
        return `${model} was sold for ${soldPrice.toFixed(2)}$`;
    }

    currentCar () {
        if (this.availableCars.length === 0) {
            return "There are no available cars";            
        }

        let result = '';
        result += '-Available cars:\n';
        for (const car of this.availableCars) {
            result += `---${car.model} - ${car.horsepower} HP - ${car.mileage.toFixed(2)} km - ${car.price.toFixed(2)}$\n`;
        }

        return result.trimEnd();
    }

    salesReport (criteria) {
        if(criteria !== "horsepower" && criteria !== "model") {
            throw new Error('Invalid criteria!');
        }

        if (criteria === "horsepower") {
            //the sold cars must be sorted by their horsepower in descending order:
            this.soldCars.sort((a, b) => b.horsepower - a.horsepower);        
        }
        else if (criteria === "model") {
            this.soldCars.sort((a, b) => a.model.localeCompare(b.model));
        }

        let output = [`-${this.name} has a total income of ${this.totalIncome.toFixed(2)}$`];
        output.push(`-${this.soldCars.length} cars sold:`);

        //this.soldCars.map(car => output.push(`---${car.model} - ${car.horsepower} HP - ${car.soldPrice.toFixed(2)}$`));
        for (const car of this.soldCars) {
            output.push(`---${car.model} - ${car.horsepower} HP - ${car.soldPrice.toFixed(2)}$`);
        }

        return output.join('\n');
    }
}

let dealership = new CarDealership('SoftAuto');
dealership.addCar('Toyota Corolla', 100, 3500, 190000);
dealership.addCar('Mercedes C63', 300, 29000, 187000);
dealership.addCar('Audi A3', 120, 4900, 240000);
dealership.sellCar('Toyota Corolla', 230000);
dealership.sellCar('Mercedes C63', 110000);
console.log(dealership.salesReport('horsepower'));
