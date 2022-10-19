class SmartHike {
    constructor (username) {
        this.username = username;
        //The goals property is an object, representing a key-value pair of a peak’s name and its altitude.
        this.goals = {};
        this.listOfHikes = [];
        this.resources = 100;
    }

    addGoal(peak, altitude) {
        //If the goal does not exist in the goals object:
        if (this.goals[peak] == undefined) {
            //Add the goal to the current peak:
            this.goals[peak] = Number(altitude);
            return `You have successfully added a new goal - ${peak}`;
        }
        else {
            return `${peak} has already been added to your goals`
        }
    }

    hike (peak, time, difficultyLevel) {
        //If the peak doesn’t exist in the goals object:
        if (this.goals[peak] == undefined) { 
            throw new Error(`${peak} is not in your current goals`);
        }
        else {
            //If the peak exists in the goals object but the resources are already 0:
            if (this.resources === 0) {
                throw new Error("You don't have enough resources to start the hike");
            }

            let usedResourses = time * 10;
            let difference = this.resources - usedResourses;

            //try this -> let difference = this.resources - (this.time * 10);

            if (difference < 0) {
                return "You don't have enough resources to complete the hike";
            }
            else {
                this.resources -= usedResourses;
                this.listOfHikes.push({ peak, time, difficultyLevel });
                return `You hiked ${peak} peak for ${time} hours and you have ${this.resources}% resources left`;
            }
        }
    }

    rest (time) {
        this.resources += time * 10;

        if (this.resources >= 100) {
            this.resources = 100;
            return `Your resources are fully recharged. Time for hiking!`
        }
        else {
            return `You have rested for ${time} hours and gained ${time*10}% resources`
        }
    }

    showRecord (criteria) {
        //if the list of hikes is empty:
        if (this.listOfHikes.length == 0) {
            return `${this.username} has not done any hiking yet`
        }

        //Find all hikes from the list of hikes depending on the given criterion "hard" or "easy" and find the best hike:
        if(criteria === "hard" || criteria === "easy") {
            //All hikes that matches the given criteria:
            let allHikes = this.listOfHikes.filter((hike) => hike.difficultyLevel === criteria);

            //Sort all hikes and find the best one:
            let sortedHikes = allHikes.sort((a, b) => a.time - b.time)
            //Sort returns an array so it is iterable and i can get the first element:
            let bestHike = sortedHikes[0];

            if (bestHike === undefined) {
                return `${this.username} has not done any ${criteria} hiking yet`  
            }

            return `${this.username}'s best ${criteria} hike is ${bestHike.peak} peak, for ${bestHike.time} hours`;
        }
        else if (criteria === "all") {
            let result = ["All hiking records:"]
            //try this -> this.result = "All hiking records:"

            this.listOfHikes.forEach(hike => {
                result.push(`${this.username} hiked ${hike.peak} for ${hike.time} hours`);
            });

            return result.join("\n");
        }
    }
}

const user = new SmartHike('Vili');
user.addGoal('Musala', 2925);
user.hike('Musala', 8, 'hard');
console.log(user.showRecord('easy'));
user.addGoal('Vihren', 2914);
user.hike('Vihren', 4, 'hard');
console.log(user.showRecord('hard'));
user.addGoal('Rui', 1706);
user.hike('Rui', 3, 'easy');
console.log(user.showRecord('all'));


