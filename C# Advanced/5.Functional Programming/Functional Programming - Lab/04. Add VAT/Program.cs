using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<decimal> numbers = Console.ReadLine().Split(", ").Select(decimal.Parse).ToList();

            numbers = numbers.Select(n => n + n * 0.2m).ToList();

            numbers.ForEach(n => Console.WriteLine($"{n:f2}"));
        }
    }
}
