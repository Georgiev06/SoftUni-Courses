using System;

namespace P10._TopNumber
{
    internal class Program
    {
        static bool isDividible(int input)
        {
            int sum = 0;

            while (input > 0)
            {
                sum += input % 10;
                input /= 10;
            }
            bool isDivisible = sum % 8 == 0;
            return isDivisible;
        }
        static bool cntOdddigits(int input)
        {
            while (input > 0)
            {
                int curetntDigit = input % 10;

                if (curetntDigit % 2 == 1)
                {
                    return true;
                }
                input /= 10;
            }
            return false;
        }
        static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                if (isDividible(i) && cntOdddigits(i))
                {
                    Console.WriteLine(i);
                }
            }

        }
    }
}
