using System;
using System.Collections.Generic;
using System.Linq;


namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string lowerCaseWord = word.ToLower();

                if (counts.ContainsKey(lowerCaseWord))
                {
                    counts[lowerCaseWord] ++;
                }
                else
                {
                    counts.Add(lowerCaseWord, 1);
                }
            }

            foreach (var item in counts)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write($"{item.Key} ");
                }
            }
        }
    }
}
