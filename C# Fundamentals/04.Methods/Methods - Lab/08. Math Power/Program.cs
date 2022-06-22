using System;

namespace _08._Math_Power
{
    internal class Program
    {
        static double CalculatePower(double number, double power)
        {
            double result = 0d;
            result = Math.Pow(number, power);
            //Console.WriteLine(result);
            return result;
        }
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            double result = CalculatePower(number, power);
            Console.WriteLine(result);

        }
    }
}
