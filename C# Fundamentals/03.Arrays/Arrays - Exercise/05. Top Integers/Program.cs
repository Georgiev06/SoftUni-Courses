using System;

namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] topIntegers = new int[arr.Length];
            int topIntegersIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int currNumber = arr[i];

                bool istopIntegers = true;

                for (int j = i + 1; j < arr.Length; j++) // Всички индекси от дясно до края
                {
                    int nextNumber = arr[j];

                    if (currNumber <= nextNumber)
                    {
                        istopIntegers = false;
                        break;
                    }
                }
                if (istopIntegers)
                {
                    topIntegers[topIntegersIndex] = currNumber;
                    topIntegersIndex++;
                }
            }

            for (int i = 0; i < topIntegersIndex; i++)
            {
                Console.Write($"{topIntegers[i]} ");
            }
        }
    }
}
