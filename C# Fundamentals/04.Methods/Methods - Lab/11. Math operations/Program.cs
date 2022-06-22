using System;

namespace _11._Math_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());
            double calculate = MathOperations(number, @operator, secondNumber);
            Console.WriteLine(calculate);
        }

        static double MathOperations(int number, string @operator, int secondNumber)
        {
            double result = 0;

            switch (@operator)
            {
                case "+":
                    result = number + secondNumber;
                    break;
                case "*":
                    result = number * secondNumber;
                    break;
                case "-":
                    result = number - secondNumber;
                    break;
                case "/":
                    result = number / secondNumber;
                    break;
            }
            return result;
        }
    }
}
