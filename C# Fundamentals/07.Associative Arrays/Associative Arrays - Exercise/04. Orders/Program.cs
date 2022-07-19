using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();

            string command;

            while ((command = Console.ReadLine()) != "buy")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string nameOfTheProduct = commandArgs[0];
                double price = double.Parse(commandArgs[1]);
                double quantity = double.Parse(commandArgs[2]);

                if (!products.ContainsKey(nameOfTheProduct))
                {
                    products.Add(nameOfTheProduct, new List<double>());
                }

                products[nameOfTheProduct][0] += quantity;
                products[nameOfTheProduct][1] = price;

            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {(product.Value[0] * product.Value[1]):f2}");
            }
        }
    }
}
