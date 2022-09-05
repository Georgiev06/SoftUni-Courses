using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numberRange = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<int> numbers = new List<int>();

            for (int i = numberRange[0]; i <= numberRange[1]; i++)
            {
                numbers.Add(i);
            }

            string command = Console.ReadLine();

            Predicate<int> IsEven = x => x % 2 == 0;
  
            Predicate<int> IsOdd = x => x % 2 != 0;

            List<int> result;

            if (command == "even")
            {
                result =  numbers.FindAll(IsEven);
                Console.WriteLine(String.Join(" ", result));
            }
            else if (command == "odd")
            {
                result = numbers.FindAll(IsOdd);
                Console.WriteLine(String.Join(" ", result));
            }

        }
    }
}
