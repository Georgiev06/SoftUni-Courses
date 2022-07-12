using System;

namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int addAndsubtract = AddAndSubtract(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine(addAndsubtract);


        }
        static int AddAndSubtract(int firstNumber, int secondNumber, int thirdNumber)
        {
            int sum = 0;
            sum = (firstNumber + secondNumber) - thirdNumber;
            return sum;
        }

    }
}

