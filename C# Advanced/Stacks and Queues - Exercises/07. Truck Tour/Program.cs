using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                queue.Enqueue(input);
            }

            int startIndex = 0;

            while (true)
            {
                int totalLiters = 0;
                bool IsComplete = true;

                foreach (int[] item in queue)
                {
                    int liters = item[0];
                    int distance = item[1];

                    totalLiters += liters;

                    if (totalLiters - distance < 0)
                    {
                        startIndex++;
                        int[] currentPump = queue.Dequeue();
                        queue.Enqueue(currentPump);
                        IsComplete = false;
                        break;
                    }

                    totalLiters -= distance;
                }

                if (IsComplete)
                {
                    Console.WriteLine(startIndex);
                    break;
                }
            }
        }
    }
}
