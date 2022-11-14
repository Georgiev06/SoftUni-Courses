using System;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tiresList = new List<Tire[]>();

            string command = Console.ReadLine();

            while (command != "No more tires")
            {
                var splittedCommand = command.Split();
                var tire1 = new Tire(int.Parse(splittedCommand[0]), double.Parse(splittedCommand[1]));
                var tire2 = new Tire(int.Parse(splittedCommand[2]), double.Parse(splittedCommand[3]));
                var tire3 = new Tire(int.Parse(splittedCommand[4]), double.Parse(splittedCommand[5]));
                var tire4 = new Tire(int.Parse(splittedCommand[6]), double.Parse(splittedCommand[7]));

                var tires = new Tire[] { tire1, tire2, tire3, tire4 };

                tiresList.Add(tires);

                command = Console.ReadLine();
            }


            List<Engine> engineList = new List<Engine>();

            string command2 = Console.ReadLine();

            while (command2 != "Engines done")
            {
                var splittedCommand2 = command2.Split();

                var engine = new Engine(int.Parse(splittedCommand2[0]), double.Parse(splittedCommand2[1]));

                engineList.Add(engine);

                command2 = Console.ReadLine();
            }

            string command3 = Console.ReadLine();

            while (command2 != "Show special")
            {
                var splittedCommand3 = command3.Split();

                string make = splittedCommand3[0];
                string model = splittedCommand3[1];
                int year = int.Parse(splittedCommand3[2]);
                double fuelQuantity = double.Parse(splittedCommand3[3]);
                double fuelConsumption = double.Parse(splittedCommand3[4]);
                int engineIndex = int.Parse(splittedCommand3[5]);
                int tiresIndex = int.Parse(splittedCommand3[6]);

                Car newCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engineIndex, tiresIndex);
            }
        }
    }
}
