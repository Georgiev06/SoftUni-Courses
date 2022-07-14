using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string product = Console.ReadLine();
                names.Add(product);
            }
            names.Sort();

            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{names[i]}");
            }

        }
    }
}
