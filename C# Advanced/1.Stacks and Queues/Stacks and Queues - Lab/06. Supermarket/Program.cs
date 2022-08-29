using System;
using System.Collections.Generic;

namespace _06._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Queue<string> queue = new Queue<string>();

            while (input != "End")
            {
                if (input == "Paid")
                {
                    while (queue.Count > 0)
                    {
                        string name = queue.Dequeue();
                        Console.WriteLine(name);
                    }
                    queue.Clear();
                }
                else
                {
                    queue.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
