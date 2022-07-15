using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                List<string> numbersSeparatedBySpace = numbers[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int k = 0; k < numbersSeparatedBySpace.Count; k++)
                {
                    Console.Write($"{numbersSeparatedBySpace[k]} ");
                }
            }

        }

    }
}

