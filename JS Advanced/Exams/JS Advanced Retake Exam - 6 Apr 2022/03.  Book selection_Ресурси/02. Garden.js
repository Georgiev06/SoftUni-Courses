class Garden {
    constructor(spaceAvailable) {
        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = [];
    }

    addPlant(plantName, spaceRequired) {
        if (this.spaceAvailable < spaceRequired) {
            throw new Error("Not enough space in the garden.");
        }
        else {
            this.plants.push({
                plantName,
                spaceRequired,
                ripe: false,
                quantity: 0
            });

            this.spaceAvailable -= spaceRequired;
            return `The ${plantName} has been successfully planted in the garden.`
        }

    }

    ripenPlant(plantName, quantity) {
        //Get the plant:
        let plant = this.plants.find(plant => plant.plantName === plantName);

        //There is no plant in the garden
        if (plant === undefined) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (plant.ripe === true) {
            throw new Error(`The ${plantName} is already ripe.`);
        }

        if (quantity <= 0) {
            throw new Error(`The quantity cannot be zero or negative.`);
        }

        plant.ripe = true;
        plant.quantity += quantity;

        if (quantity === 1) {
            return `${quantity} ${plantName} has successfully ripened.`
        }
        else {
            return `${quantity} ${plantName}s have successfully ripened.`
        }
    }

    harvestPlant(plantName) {
        //Get the plant:
        let plant = this.plants.find(plant => plant.plantName === plantName);

        if (plant === undefined) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (plant.ripe === false) {
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        }

        //Remove the plant from the plants array
        //Plant will be with unique names so this should return every other plant:
        this.plants = this.plants.filter(plant => plant.plantName !== plantName);
        
        this.spaceAvailable += plant.spaceRequired;

        this.storage.push({
            plantName : plant.plantName,
            quantity : plant.quantity
        })

        return `The ${plantName} has been successfully harvested.`
    }

    generateReport() {
        let result = [`The garden has ${this.spaceAvailable} free space left.`]
        let sortedPlants = this.plants.sort((a, b) => a.plantName - b.plantName).map(p => p.plantName);

        result.push(`Plants in the garden: ${sortedPlants.join(', ')}`);

        if (this.storage.length === 0) {
            result.push("Plants in storage: The storage is empty.");
        }
        else {
            let formatedStorage = this.storage.map(plant => `${plant.plantName} (${plant.quantity})`);
            result.push(`Plants in storage: ${formatedStorage.join(', ')}`);
        }

        return result.join("\n");
    }
}

const myGarden = new Garden(250)
console.log(myGarden.addPlant('apple', 20));
console.log(myGarden.addPlant('orange', 200));
console.log(myGarden.addPlant('raspberry', 10));
console.log(myGarden.ripenPlant('apple', 10));
console.log(myGarden.ripenPlant('orange', 1));
console.log(myGarden.harvestPlant('orange'));
console.log(myGarden.generateReport());






