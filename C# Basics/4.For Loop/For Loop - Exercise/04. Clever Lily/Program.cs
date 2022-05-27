using System;

namespace _04._Clever_Lily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input from the user
            int ageOfLily = int.Parse(Console.ReadLine());
            double priceOfLaundry = double.Parse(Console.ReadLine());
            int priceForOneToy = int.Parse(Console.ReadLine());

            int toys = 0;
            int money = 0;
            int totalMoney = 0;

            //Logic for solving the problem
            for (int i = 1; i <= ageOfLily; i++)
            {
                money += 5;
                if (i % 2 == 0)
                {
                    totalMoney += money - 1;
                }
                else if (i % 2 != 0)
                {
                    toys++;
                }
            }
            totalMoney += toys * priceForOneToy;

            //Printing the final result
            if (totalMoney >= priceOfLaundry)
            {
                Console.WriteLine($"Yes! {totalMoney - priceOfLaundry:f2}");
            }
            else
            {
                Console.WriteLine($"No! {priceOfLaundry - totalMoney:f2}");
            }
        }
    }
}
