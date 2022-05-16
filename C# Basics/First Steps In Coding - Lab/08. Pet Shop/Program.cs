using System;

namespace _08._Pet_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int theNumberOfPackagesOfDogFood = int.Parse(Console.ReadLine());
            int theNumberOfPackagesOfCatFood = int.Parse(Console.ReadLine());

            double onePackOfDogFood = theNumberOfPackagesOfDogFood * 2.50;
            double onePackaOfCatFood = theNumberOfPackagesOfCatFood * 4.00;
            double finalSum = onePackOfDogFood + onePackaOfCatFood;
            Console.WriteLine($"{finalSum} lv.");
        }
    }
}
