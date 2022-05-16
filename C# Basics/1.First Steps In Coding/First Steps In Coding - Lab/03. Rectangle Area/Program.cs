using System;

namespace _03._Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sideA = int.Parse(Console.ReadLine());
            int sideB = int.Parse(Console.ReadLine());
            int result = sideA * sideB;
            Console.WriteLine(result);
        }
    }
}
