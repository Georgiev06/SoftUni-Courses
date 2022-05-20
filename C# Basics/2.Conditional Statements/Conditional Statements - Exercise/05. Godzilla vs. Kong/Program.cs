using System;

namespace _05._Godzilla_vs._Kong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //INPUT FROM THE USER
            double filmBudged = double.Parse(Console.ReadLine());
            int numberOfStuntmans = int.Parse(Console.ReadLine());
            double priceOfClothes = double.Parse(Console.ReadLine());

            //LOGIG FOR SOLVING THE PROBLEM
            double priceForFilmDecor = filmBudged * 0.10;
            double totalPriceForClothes = numberOfStuntmans * priceOfClothes;
            if (numberOfStuntmans > 150)
            {
                totalPriceForClothes *= 0.90;
            }

            double totalMoney = priceForFilmDecor + totalPriceForClothes;
            //PRINTING THE FINAL RESULT
            if (totalMoney > filmBudged)
            {
                double neededMoney = totalMoney - filmBudged;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {neededMoney:f2} leva more.");
            }
            else
            {
                double moneyLeft = filmBudged - totalMoney;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {moneyLeft:f2} leva left.");
            }
        }
    }
}
