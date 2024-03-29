﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                int number = queue.Dequeue();

                if (number % 2 == 0)
                {
                    queue.Enqueue(number);
                }
            }
            Console.WriteLine($"{string.Join(", ", queue)}");
        }
    }
}
