using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> IsDivisible = (x, y) => x % y == 0;

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToArray();

            int y = int.Parse(Console.ReadLine());

            List<int> result = numbers.Where(x => !IsDivisible(x, y)).ToList();

            Console.WriteLine(String.Join(" ", result)); 
        }
    }
}
