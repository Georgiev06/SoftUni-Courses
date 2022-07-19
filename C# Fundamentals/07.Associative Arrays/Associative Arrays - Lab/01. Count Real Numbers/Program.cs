using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            SortedDictionary<int, int> occurrences = new SortedDictionary<int, int>();

            foreach (int number in numbers)
            {
                if (occurrences.ContainsKey(number))
                {
                    occurrences[number] += 1;
                }
                else
                {
                    occurrences.Add(number, 1);
                }
            }

            foreach (var item in occurrences)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
