using System;

namespace _03._Calculations
{
    internal class Program
    {
        static void Add(int a, int b)
        {
            int result = a + b;
            Console.WriteLine(result);
        }
        static void Multiply(int a, int b)
        {
            int result = a * b;
            Console.WriteLine(result);
        }
        static void Subtract(int a, int b)
        {
            int result = a - b;
            Console.WriteLine(result);
        }
        static void Divide(int a, int b)
        {
            int result = a / b;
            Console.WriteLine(result);
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            switch (input)
            {
                case "add":
                    Add(a, b);
                    break;
                case "multiply":
                    Multiply(a, b);
                    break;
                case "subtract":
                    Subtract(a, b);
                    break;
                case "divide":
                    Divide(a, b);
                    break;
            }
        }
    }
}
