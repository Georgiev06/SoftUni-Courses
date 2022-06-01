using System;

namespace _07._Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());//Широчина
            int lenght = int.Parse(Console.ReadLine());//Дължина
            int hight = int.Parse(Console.ReadLine());//Височина
            int totalCubicMetters = width * lenght * hight;
            int sumOfCubicMetters = 0;
            string command = Console.ReadLine();

            while (command != "Done")
            {
                int currentCubicMetters = int.Parse(command);
                sumOfCubicMetters += currentCubicMetters;

                if (totalCubicMetters < sumOfCubicMetters)
                {
                    int neededCubicMetters = sumOfCubicMetters - totalCubicMetters;
                    Console.WriteLine($"No more free space! You need {neededCubicMetters} Cubic meters more.");
                    break;
                }
                command = Console.ReadLine();

            }

            if (command == "Done")
            {
                int cubicMettersFree = totalCubicMetters - sumOfCubicMetters;
                Console.WriteLine($"{cubicMettersFree} Cubic meters left.");
            }
        }
    }
}
