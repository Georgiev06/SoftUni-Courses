using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");

            Queue<string> queue = new Queue<string>(songs);

            while (queue.Count > 0)
            {
                string[] command = Console.ReadLine().Split(' ').ToArray();

                string commandType = command[0];

                if (commandType == "Play")
                {
                    queue.Dequeue();
                }
                else if (commandType == "Add")
                {
                    string song = string.Join(" ", command.Skip(1));

                    if (queue.Contains(song))
                    {  
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(song);
                    }

                }
                else if (commandType == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
