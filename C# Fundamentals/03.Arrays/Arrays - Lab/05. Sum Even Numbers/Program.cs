using System;

namespace _05._Sum_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] items = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sum = 0;

            for (int i = 0; i < items.Length; i++)
            {
                int currNum = items[i];
                if (currNum % 2 == 0)
                {
                    sum += currNum;
                }

            }

            Console.WriteLine(sum);
        }
    }
}
