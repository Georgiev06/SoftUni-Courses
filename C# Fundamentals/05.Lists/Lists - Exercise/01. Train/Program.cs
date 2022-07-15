using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacityOfAWagon = int.Parse(Console.ReadLine());
            int sum = 0;

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "Add")
                {
                    sum = int.Parse(tokens[1]);
                    wagons.Add(sum);
                }
                else
                {
                    sum = int.Parse(tokens[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if ((wagons[i] + sum) <= maxCapacityOfAWagon)
                        {
                            wagons[i] += sum;
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", wagons));
        }
    }
}

