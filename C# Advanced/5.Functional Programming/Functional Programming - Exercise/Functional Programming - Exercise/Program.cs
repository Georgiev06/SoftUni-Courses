using System;
using System.Linq;

namespace Functional_Programming___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNumber = numbers =>
            {
                int minValue = int.MaxValue;

                foreach (var num in numbers)
                {
                    if (num < minValue)
                    {
                        minValue = num;
                    }
                }
                return minValue;
            };

            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int result = minNumber(inputNumbers);

            Console.WriteLine(result);
        }
    }
}
