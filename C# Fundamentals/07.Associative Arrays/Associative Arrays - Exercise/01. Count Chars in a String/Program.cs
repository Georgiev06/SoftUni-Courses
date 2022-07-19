using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string text = Console.ReadLine();

            Dictionary<char, int> numberChar = new Dictionary<char, int>();

            foreach (var keyValuePair in text)
            {
                if (!numberChar.ContainsKey(keyValuePair))
                {
                    numberChar[keyValuePair] = 1;
                }
                else
                {
                    numberChar[keyValuePair]++;
                }
            }

            foreach (var kvp in numberChar.Where(a => a.Key != ' '))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
            
        }
    }
}
