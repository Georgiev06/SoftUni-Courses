using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Vehicle_Catalogue
{
    public class Vehicle_Catalogue
    {
        public static void Main()
        {
            List<Vehicle> catalogue = new List<Vehicle>();     

            while (true)
            {
                string[] inputTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (inputTokens[0] == "End")
                {
                    break;
                }

                string type = inputTokens[0].ToLower();
                string model = inputTokens[1];
                string color = inputTokens[2].ToLower();
                int horsePower = int.Parse(inputTokens[3]);
                var currentVehicle = new Vehicle(type, model, color, horsePower);

                catalogue.Add(currentVehicle);
            }

            while (true)
            {
                string model = Console.ReadLine();
                if (model == "Close the Catalogue")
                {
                    break;
                }

                Console.WriteLine(catalogue.Find(x => x.Model == model));
            }

            var onlyCars = catalogue.Where(x => x.Type == "car").ToList();
            var onlyTrucks = catalogue.Where(x => x.Type == "truck").ToList();
            double totalCarsHorsepower = 0;
            double totalTrucksHorsepower = 0;

            foreach (var car in onlyCars)
            {
                totalCarsHorsepower += car.HorsePower;
            }

            foreach (var truck in onlyTrucks)
            {
                totalTrucksHorsepower += truck.HorsePower;
            }

            double averageCarsHorsepower = totalCarsHorsepower / onlyCars.Count;
            double averageTrucksHorsepower = totalTrucksHorsepower / onlyTrucks.Count;
            if (averageCarsHorsepower > 0 && averageTrucksHorsepower > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsepower:f2}.");
                Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsepower:f2}.");
            }
            else if (averageCarsHorsepower > 0 && averageTrucksHorsepower <= 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsepower:f2}.");
            }
            else if (averageCarsHorsepower <= 0 && averageTrucksHorsepower > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsepower:f2}.");
            }
        }
    }

    public class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public override string ToString()
        {
            string vehicleStr = $"Type: {(this.Type == "car" ? "Car" : "Truck")}{Environment.NewLine}" +
                                $"Model: {this.Model}{Environment.NewLine}" +
                                $"Color: {this.Color}{Environment.NewLine}" +
                                $"Horsepower: {this.HorsePower}";

            return vehicleStr;
        }
    }
}