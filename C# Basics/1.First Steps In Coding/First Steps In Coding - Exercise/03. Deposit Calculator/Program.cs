using System;

namespace _03._Deposit_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double depozit = double.Parse(Console.ReadLine());
            int srok = int.Parse(Console.ReadLine());
            double lihva = double.Parse(Console.ReadLine());

            double sum = depozit + srok * ((depozit * lihva / 100) / 12);

            Console.WriteLine(sum);
        }
    }
}
