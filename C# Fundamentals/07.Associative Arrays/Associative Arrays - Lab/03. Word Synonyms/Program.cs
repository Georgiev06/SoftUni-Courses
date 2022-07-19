using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pairCount = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < pairCount; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();


                if (dictionary.ContainsKey(word))
                {
                    dictionary[word].Add(synonym);
                }
                else
                {
                    List<string> newList = new List<string>() { synonym };
                    dictionary.Add(word, newList);
                }
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}
