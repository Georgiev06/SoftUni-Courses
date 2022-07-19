using System;
using System.Collections.Generic;
using System.Linq;


namespace _04._Word_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] result = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Where(word => word.Length % 2 == 0)
               .ToArray();


            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
