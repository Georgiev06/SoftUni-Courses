using System;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            int sum = 0;

            int[] arr = new int[wagons];

            for (int i = 0; i < wagons; i++)
            {

                arr[i] = int.Parse(Console.ReadLine());
                sum += arr[i];

            }

            Console.Write(String.Join(" ", arr));
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
