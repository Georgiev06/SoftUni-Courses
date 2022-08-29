using System;
using System.Collections.Generic;

namespace _08._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int passedCarsCount = 0;

            Queue<string> cars = new Queue<string>();

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }

                        var car = cars.Dequeue();
                        Console.WriteLine($"{car} passed!");
                        passedCarsCount++;
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{passedCarsCount} cars passed the crossroads.");
        }
    }
}
