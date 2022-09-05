using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> getMinNumber = numbers =>
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

            int[] inputNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int result = getMinNumber(inputNumbers);

            Console.WriteLine(result);
        }
    }
}
