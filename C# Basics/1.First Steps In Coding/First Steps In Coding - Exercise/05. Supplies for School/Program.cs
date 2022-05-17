using System;

namespace _05._Supplies_for_School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countPens = int.Parse(Console.ReadLine());
            int CountMarkers = int.Parse(Console.ReadLine());
            int litters = int.Parse(Console.ReadLine());
            int percent = int.Parse(Console.ReadLine());

            double pricePens = countPens * 5.80;
            double priceMarkers = CountMarkers * 7.20;
            double pricePrep = litters * 1.20;
            double sum = pricePens + priceMarkers + pricePrep;

            sum = sum - (percent / 100.0) * sum;
            Console.WriteLine(sum);
        }
    }
}
