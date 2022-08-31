using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> elements = new SortedSet<string>();

            int n = int.Parse(Console.ReadLine());

            FillSet(elements, n);

            Console.WriteLine(string.Join(" ", elements));
        }

        private static SortedSet<string> FillSet(SortedSet<string> elements, int n)
        {
            for (int i = 0; i < n; i++)
            {
                List<string> compunds = Console.ReadLine().Split().ToList();
                compunds.ForEach(compund => elements.Add(compund));
            }
            return elements;
        }
    }
}
