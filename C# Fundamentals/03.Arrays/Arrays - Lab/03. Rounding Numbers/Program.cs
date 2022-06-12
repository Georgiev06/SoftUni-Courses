using System;
using System.Linq;

namespace _03._Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    nums[i] = 0;
                }
                Console.WriteLine($"{nums[i]} => {(int)Math.Round(nums[i], MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
