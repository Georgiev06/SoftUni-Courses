using System;

namespace _03._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;

            while (true)
            {
                int currentNum = int.Parse(Console.ReadLine());
                sum += currentNum;
                if (sum < num)
                {
                    continue;
                }
                break;
            }
            Console.WriteLine(sum);

        }
    }
}
