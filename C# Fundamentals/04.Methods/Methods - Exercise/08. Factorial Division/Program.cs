using System;

namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = Math.Abs(int.Parse(Console.ReadLine()));
            double num2 = Math.Abs(int.Parse(Console.ReadLine()));
            FactorialDivision(num1, num2);
        }
        static void FactorialDivision(double num1, double num2)
        {
            for (double i = num1 - 1; i > 0; i--)
            {
                num1 *= i;
            }
            for (double j = num2 - 1; j > 0; j--)
            {
                num2 *= j;
            }

            Console.WriteLine($"{num1 / num2:f2}");
        }
    }
}
