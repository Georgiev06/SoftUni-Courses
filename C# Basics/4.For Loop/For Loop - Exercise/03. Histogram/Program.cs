using System;

namespace _03._Histogram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;

            //Logic for solving the problem 
            for (int i = 0; i < numbers; i++)
            {
                int n = int.Parse(Console.ReadLine());
                if (n < 200)
                {
                    p1++;
                }
                else if (n < 400)
                {
                    p2++;
                }
                else if (n < 600)
                {
                    p3++;
                }
                else if (n < 800)
                {
                    p4++;
                }
                else
                {
                    p5++;
                }
            }

            double percentConvertP1 = (double)p1 / numbers * 100;
            double percentConvertP2 = (double)p2 / numbers * 100;
            double percentConvertP3 = (double)p3 / numbers * 100;
            double percentConvertP4 = (double)p4 / numbers * 100;
            double percentConvertP5 = (double)p5 / numbers * 100;

            //Printing the final result
            Console.WriteLine($"{percentConvertP1:f2}%");
            Console.WriteLine($"{percentConvertP2:f2}%");
            Console.WriteLine($"{percentConvertP3:f2}%");
            Console.WriteLine($"{percentConvertP4:f2}%");
            Console.WriteLine($"{percentConvertP5:f2}%");
        }
    }
}
