using System;

namespace _06._Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Area(int a, int b)
        {
            int result = a * b;
            Console.WriteLine(result);
        }
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Area(a, b);
        }
    }
}