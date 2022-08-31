using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> productShop = new Dictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();  

            while(input != "Revision")
            {
                string[] splittedInput = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = splittedInput[0];
                string product = splittedInput[1];
                double price = double.Parse(splittedInput[2]);

                if (!productShop.ContainsKey(shop))
                {
                    productShop.Add(shop, new Dictionary<string, double>());
                }
                productShop[shop].Add(product, price);

                input = Console.ReadLine();
            }

            productShop = productShop.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var shop in productShop)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
