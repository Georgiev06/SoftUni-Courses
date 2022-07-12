using System;
using System.Linq;

namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();
            int vowelsCount = GetVowelsCount(words);
            Console.WriteLine(vowelsCount);
        }

        static int GetVowelsCount(string words)
        {
            //a, e, i, o, u
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

            int vowelsCount = 0;
            foreach (char ch in words.ToLower())
            {
                if (vowels.Contains(ch))
                {
                    vowelsCount++;
                }
            }
            return vowelsCount;
        }
    }
}
