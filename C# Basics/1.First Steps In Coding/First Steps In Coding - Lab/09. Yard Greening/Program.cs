using System;

namespace _09._Yard_Greening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double yards = double.Parse(Console.ReadLine());

            double price = yards * 7.61;
            double discount = price * 0.18;
            double sum = price - discount;

            Console.WriteLine($"The final price is: {price - discount} lv.");
            Console.WriteLine($"The discount is: {price * 0.18} lv.");
        }
    }
}
