using System;

namespace _02._Print_Numbers_in_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            int[] items = new int[numbers];

            for (int i = 0; i < numbers; i++)
            {
                items[i] = int.Parse(Console.ReadLine());
            }

            for (int i = items.Length - 1; i >= 0; i--)
            {
                Console.Write($"{items[i]} ");

            }

            Console.WriteLine();
        }
    }
}
