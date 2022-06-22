using System;

namespace _05._Orders
{
    internal class Program
    {
        static void Water(int quantity, double price)
        {
            price = 1.00;
            Console.WriteLine($"{quantity * price:f2}");
        }
        static void Coffee(int quantity, double price)
        {
            price = 1.50;
            Console.WriteLine($"{quantity * price:f2}");
        }
        static void Coke(int quantity, double price)
        {
            price = 1.40;
            Console.WriteLine($"{quantity * price:f2}");
        }
        static void Snacks(int quantity, double price)
        {
            price = 2.00;
            Console.WriteLine($"{quantity * price:f2}");
        }
        static void Main(string[] args)
        {

            // const double priceOfTheCoffee = 1.50;
            // const double priceOfTheWater = 1.00;
            // const double priceOfTheCoke = 1.40;
            // const double priceOfTheSnacks = 2.00;

            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double price = 0.00;

            switch (product)
            {
                case "water":
                    Water(quantity, price);
                    break;
                case "coffee":
                    Coffee(quantity, price);
                    break;
                case "coke":
                    Coke(quantity, price);
                    break;
                case "snacks":
                    Snacks(quantity, price);
                    break;
            }


        }
    }
}
