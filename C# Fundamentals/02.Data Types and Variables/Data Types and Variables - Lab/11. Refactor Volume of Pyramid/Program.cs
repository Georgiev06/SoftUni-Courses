using System;

namespace _11._Refactor_Volume_of_Pyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Length: ");
            double Length = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            double Width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            double Heigth = double.Parse(Console.ReadLine());
            double Volume = (Length * Width * Heigth) / 3;
            Console.Write($"Pyramid Volume: {Volume:f2}");
        }
    }
}
