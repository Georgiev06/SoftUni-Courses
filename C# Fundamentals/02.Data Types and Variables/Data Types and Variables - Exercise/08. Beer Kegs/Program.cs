using System;

namespace _08._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int beerKegs = int.Parse(Console.ReadLine());
            double biggestKeg = double.MinValue;
            string modelOfTheKeg = string.Empty;

            for (int i = 0; i < beerKegs; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * radius * radius * height;

                if (volume > biggestKeg)
                {
                    biggestKeg = volume;
                    modelOfTheKeg = model;
                }
            }
            Console.WriteLine(modelOfTheKeg);
        }
    }
}
