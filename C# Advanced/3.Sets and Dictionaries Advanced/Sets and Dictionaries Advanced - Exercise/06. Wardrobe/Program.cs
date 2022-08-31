using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string colour = input[0];
                string[] clothes = input[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(colour))
                {
                    wardrobe.Add(colour, new Dictionary<string, int>());
                }

                foreach (var item in clothes)
                {
                    if (!wardrobe[colour].ContainsKey(item))
                    {
                        wardrobe[colour].Add(item, 0);
                    }
                    wardrobe[colour][item]++; 
                }
            }

            string[] clothesToSearch = Console.ReadLine().Split();
            string color = clothesToSearch[0];
            string cloth = clothesToSearch[1];

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var kvp in item.Value)
                {
                    if (color == item.Key && cloth == kvp.Key)
                    {
                        Console.WriteLine($"* {kvp.Key} - {kvp.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {kvp.Key} - {kvp.Value}");
                    }
                }
            }
        }
    }
}
