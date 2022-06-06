using System;

namespace _04._Print_and_sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int num = int.Parse(Console.ReadLine());
            int sum = 0;


            for (int i = input; i <= num; i++)
            {
                sum += i;
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
