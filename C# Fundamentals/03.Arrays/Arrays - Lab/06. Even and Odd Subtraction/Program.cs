using System;
using System.Linq;

namespace _06._Even_and_Odd_Subtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            int evenSum = 0;
            int oddSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currNum = numbers[i];
                if (currNum % 2 == 0)
                {
                    evenSum += currNum;
                }
                else
                {
                    oddSum += currNum;
                }
            }

            int diference = evenSum - oddSum;
            Console.WriteLine(diference);
        }
    }
}
