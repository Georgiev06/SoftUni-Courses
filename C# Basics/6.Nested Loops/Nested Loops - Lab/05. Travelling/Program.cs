using System;

namespace _05._Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            while (destination != "End")
            {
                double budget = double.Parse(Console.ReadLine());
                double savedMOney = 0;

                while (savedMOney < budget)
                {
                    savedMOney += double.Parse(Console.ReadLine());
                }

                Console.WriteLine($"Going to {destination}!");
                destination = Console.ReadLine();
            }
        }
    }
}
