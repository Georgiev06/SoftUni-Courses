using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());

            FillDictionary(numbers, n);
            PrintResult(numbers);
        }

        private static void PrintResult(Dictionary<int, int> numbers)
        {
            int num = 0;
            foreach (KeyValuePair<int, int> kvp in numbers)
            {
                if (kvp.Value % 2 == 0)
                {
                    num = kvp.Key;
                }
            }

            Console.WriteLine(num);
        }

        private static Dictionary<int, int> FillDictionary(Dictionary<int, int> numbers, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(currentNum))
                {
                    numbers.Add(currentNum, 0);
                }
                numbers[currentNum]++;
            }
            return numbers; 
        }
    }
}
