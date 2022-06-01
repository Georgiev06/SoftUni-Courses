using System;

namespace _06._Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine()); 
            int width = int.Parse(Console.ReadLine()); 
            int TotalPeaces = width * lenght;

            while (TotalPeaces > 0)
            {
                string input = Console.ReadLine();
                if (input == "STOP")
                {
                    break;
                }
                int peacesOfCake = int.Parse(input);
                TotalPeaces -= peacesOfCake;

            }

            if (TotalPeaces >= 0)
            {
                Console.WriteLine($"{TotalPeaces} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(TotalPeaces)} pieces more.");
            }

        }
    }
}
