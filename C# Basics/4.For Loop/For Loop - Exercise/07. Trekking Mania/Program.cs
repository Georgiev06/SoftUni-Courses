using System;

namespace _07._Trekking_Mania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int goupe1 = 0;
            int goupe2 = 0;
            int goupe3 = 0;
            int goupe4 = 0;
            int goupe5 = 0;

            for (int i = 1; i <= numberOfPeople; i++)
            {
                int climbbers = int.Parse(Console.ReadLine());

                if (climbbers < 6)
                {
                    goupe1 += climbbers;
                }
                else if (climbbers < 13)
                {
                    goupe2 += climbbers;
                }
                else if (climbbers < 26)
                {
                    goupe3 += climbbers;
                }
                else if (climbbers < 41)
                {
                    goupe4 += climbbers;
                }
                else
                {
                    goupe5 += climbbers;
                }
            }

            int totalClimbers = goupe1 + goupe2 + goupe3 + goupe4 + goupe5;

            double converGoupe1 = 1.0 * goupe1 / totalClimbers * 100;
            double converGoupe2 = 1.0 * goupe2 / totalClimbers * 100;
            double converGoupe3 = 1.0 * goupe3 / totalClimbers * 100;
            double converGoupe4 = 1.0 * goupe4 / totalClimbers * 100;
            double converGoupe5 = 1.0 * goupe5 / totalClimbers * 100;

            Console.WriteLine($"{converGoupe1:f2}%");
            Console.WriteLine($"{converGoupe2:f2}%");
            Console.WriteLine($"{converGoupe3:f2}%");
            Console.WriteLine($"{converGoupe4:f2}%");
            Console.WriteLine($"{converGoupe5:f2}%");
        }
    }
}
