using System;

namespace _02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string str1 = input[0];
            string str2 = input[1];

            int minLen = Math.Min(str1.Length, str2.Length);
            int maxLen = Math.Max(str1.Length, str2.Length);
            int sum = 0;

            for (int i = 0; i < minLen; i++)
            {
                sum += str1[i] * str2[i];
            }

            if (str1.Length != str2.Length)
            {
                string longerInput = str1.Length > str2.Length ? longerInput = str1 : longerInput = str2;
                for (int i = minLen; i < maxLen; i++)
                {
                    sum += longerInput[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
