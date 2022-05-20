using System;

namespace _04._Toy_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CONSTANTS       
            double puzzlePrice = 2.60;
            double dollPrice = 3;
            double bearPrice = 4.10;
            double minionPrice = 8.20;
            double truckPrice = 2;


            //INPUT FROM THE USER
            double excursionPrice = double.Parse(Console.ReadLine());
            int numberOfPuzzels = int.Parse(Console.ReadLine());
            int numberOfDolls = int.Parse(Console.ReadLine());
            int numberOfBears = int.Parse(Console.ReadLine());
            int numberOfMinions = int.Parse(Console.ReadLine());
            int numberOfTrucks = int.Parse(Console.ReadLine());

            //LOGIG FOR SOLVING THE PROBLEM
            int toysCount = numberOfPuzzels + numberOfDolls + numberOfBears + numberOfMinions + numberOfTrucks;
            double totalprice = puzzlePrice * numberOfPuzzels + dollPrice * numberOfDolls + bearPrice * numberOfBears
                + truckPrice * numberOfTrucks + minionPrice * numberOfMinions;

            if (toysCount >= 50)
            {
                totalprice *= 0.75;
            }

            double rent = totalprice * 0.10;
            double difference = Math.Abs(rent + excursionPrice - totalprice); //Math.Abs = -20 => 20

            //PRINTING THE FINAL RESULT
            if (totalprice >= rent + excursionPrice)
            {
                Console.WriteLine($"Yes! {difference:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {difference:f2} lv needed.");
            }
        }
    }
}
