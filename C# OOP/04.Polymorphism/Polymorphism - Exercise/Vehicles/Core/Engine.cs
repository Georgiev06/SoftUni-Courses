using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core.Interfaces
{
    public class Engine : IEngine
    {
        private readonly Vehicle car;
        private readonly Vehicle truck;
        private readonly Vehicle bus;

        public Engine(Vehicle car, Vehicle truck, Vehicle bus)
        {
            this.car = car;
            this.truck = truck;
            this.bus = bus;
        }

        public void Start()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();

                string commandType = commandArgs[0];
                string vehicleType = commandArgs[1];
                double commandParams = double.Parse(commandArgs[2]);

                if (commandType == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(this.car.Drive(commandParams));
                    }
                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(this.truck.Drive(commandParams));
                    }
                    else
                    {
                        Console.WriteLine(this.bus.Drive(commandParams));
                    }
                }
                else if (commandType == "Refuel")
                {
                    try
                    {
                        if (vehicleType == "Car")
                        {
                            this.car.Refuel(commandParams);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.truck.Refuel(commandParams);
                        }
                        else
                        {
                            this.bus.Refuel(commandParams);
                        }
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }

                }
                if (commandType == "DriveEmpty")
                {
                    Console.WriteLine(this.bus.DriveEmpty(commandParams)); ;
                }

            }

            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
            Console.WriteLine(this.bus);
        }
    }
}

