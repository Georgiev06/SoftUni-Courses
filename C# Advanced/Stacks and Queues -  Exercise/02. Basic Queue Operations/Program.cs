using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToArray();

            int[] inputElements = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int toPush = inputNumbers[0];
            int toPop = inputNumbers[1];
            int spicialNumber = inputNumbers[2];

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < toPush; i++)
            {
                queue.Enqueue(inputElements[i]);
            }

            for (int i = 0; i < toPop; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(spicialNumber))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count > 0)
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
