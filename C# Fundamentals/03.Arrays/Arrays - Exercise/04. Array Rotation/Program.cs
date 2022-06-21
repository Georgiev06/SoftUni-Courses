using System;
using System.Linq;

namespace _04._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] items = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                int oldElement = items[0];
                for (int j = 0; j < items.Length - 1; j++)
                {
                    items[j] = items[j + 1];
                }

                items[items.Length - 1] = oldElement;
            }

            Console.WriteLine(string.Join(" ", items));
        }
    }
}
