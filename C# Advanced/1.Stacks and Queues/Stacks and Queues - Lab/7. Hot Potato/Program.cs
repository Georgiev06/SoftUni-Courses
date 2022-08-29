using System;
using System.Collections.Generic;

namespace _07._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine().Split();
            int tossCount = int.Parse(Console.ReadLine());
            int currentTosses = 1;
            Queue<string> queue = new Queue<string>(people);

            while (queue.Count > 1)
            {
                var kidWithPotato = queue.Dequeue();
                if (currentTosses != tossCount)
                {
                    currentTosses++;
                    queue.Enqueue(kidWithPotato);
                }
                else
                {
                    currentTosses = 1;
                    Console.WriteLine($"Removed {kidWithPotato}");
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
