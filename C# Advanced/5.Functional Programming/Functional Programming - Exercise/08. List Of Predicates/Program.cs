using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> numbers = Enumerable.Range(1, n).ToList();
            int[] inputNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<Predicate<int>> predicates = new List<Predicate<int>>();

            foreach (var number in inputNumbers )
            {
                predicates.Add(x => x % number == 0);
            }

            foreach (var number in numbers)
            {
                bool IsDivisible = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(number))
                    {
                        IsDivisible = false;
                        break;
                    }
                }
                if (IsDivisible)
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
