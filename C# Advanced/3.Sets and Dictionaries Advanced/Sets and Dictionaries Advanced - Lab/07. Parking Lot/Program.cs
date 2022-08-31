using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] splittedCommand = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string direction = splittedCommand[0];
                string carNumber = splittedCommand[1];

                if (direction == "IN")
                {
                    cars.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    cars.Remove(carNumber);
                }

                command = Console.ReadLine();
            }

            if (cars.Count <= 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            foreach (var carNumber in cars)
            {
                Console.WriteLine(carNumber);
            }
        }
    }
}
