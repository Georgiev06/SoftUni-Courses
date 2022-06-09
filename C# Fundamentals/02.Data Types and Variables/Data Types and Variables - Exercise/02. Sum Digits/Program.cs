using System;

namespace _02._Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;

            while (num > 0)
            {
                sum = sum + (num % 10);
                num = num / 10;
            }

            Console.WriteLine(sum);
        }
    }
}
