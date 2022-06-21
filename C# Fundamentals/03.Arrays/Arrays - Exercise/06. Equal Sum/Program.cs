using System;

namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    leftSum += arr[j];
                }

                for (int k = i + 1; k < arr.Length; k++)
                {
                    rightSum += arr[k];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
                else
                {
                    leftSum = 0;
                    rightSum = 0;
                }
            }

            Console.WriteLine("no");
        }
    }
}
