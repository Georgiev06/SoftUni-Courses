using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalQuantity = int.Parse(Console.ReadLine());

            int[] inputOrders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(inputOrders.Max());

            Queue<int> orders = new Queue<int>(inputOrders);

            while (orders.Count > 0 && totalQuantity >= 0)
            {
                int currentOrder = orders.Peek();

                if (totalQuantity - currentOrder < 0)
                {
                    break;
                }

                totalQuantity -= currentOrder;
                orders.Dequeue();
            }

            if (orders.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
