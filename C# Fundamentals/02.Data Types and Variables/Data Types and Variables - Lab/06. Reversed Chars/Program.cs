using System;

namespace _06._Reversed_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstLine = char.Parse(Console.ReadLine());
            char secondLine = char.Parse(Console.ReadLine());
            char thirdLine = char.Parse(Console.ReadLine());

            Console.WriteLine($"{thirdLine} {secondLine} {firstLine}");
        }
    }
}
