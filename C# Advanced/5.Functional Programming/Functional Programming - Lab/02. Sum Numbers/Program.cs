using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Func<string, int> parseToInt = x => int.Parse(x);

            int[] numbers = Console.ReadLine().Split(", ").Select(parseToInt).ToArray();
            //int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int sum = numbers.Sum();

            Console.WriteLine(numbers.Count());
            Console.WriteLine(sum);

        }
    }
}
