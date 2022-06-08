using System;

namespace _02._Pounds_to_Dollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal num = decimal.Parse(Console.ReadLine());
            decimal result = num * 1.31m;
            Console.WriteLine($"{result:f3}");
        }
    }
}
