using System;

namespace _04._Inches_to_Centimeters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double centimetres = num * 2.54;
            Console.WriteLine(centimetres);
        }
    }
}
