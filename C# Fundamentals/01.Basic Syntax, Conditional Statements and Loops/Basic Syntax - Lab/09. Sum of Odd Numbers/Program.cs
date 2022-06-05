using System;

namespace _09._Sum_of_Odd_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"{1 + (i * 2)}");
                sum += 1 + (i * 2);

            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
