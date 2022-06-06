using System;

namespace _06._Strong_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            long factorialSum = 0;

            for (int i = 0; i <= number.Length - 1; i++)
            {
                char currCh = number[i];
                int diggit = (int)currCh - 48;

                long currDigitFAct = 1;

                for (int r = diggit; r > 1; r--)
                {
                    currDigitFAct *= r;
                }

                factorialSum += currDigitFAct;
            }

            if (factorialSum == int.Parse(number))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
