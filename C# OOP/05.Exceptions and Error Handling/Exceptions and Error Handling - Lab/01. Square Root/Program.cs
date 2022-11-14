using System;

namespace _01._Square_Root
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double number = double.Parse(Console.ReadLine());
                double result = 0;
                result = GetSqrt(number);
                Console.WriteLine(result);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);  
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }

        public static double GetSqrt(double number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Invalid number.");
            }

            return Math.Sqrt(number);
        }
    }
}
