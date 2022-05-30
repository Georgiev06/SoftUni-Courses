using System;

namespace _05._Account_Balance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double total = 0;

            while (input != "NoMoreMoney")
            {
                double currentSum = double.Parse(input);

                if (currentSum < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                total += currentSum;
                Console.WriteLine($"Increase: {currentSum:f2}");
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total: {total:f2}");
        }
    }
}
