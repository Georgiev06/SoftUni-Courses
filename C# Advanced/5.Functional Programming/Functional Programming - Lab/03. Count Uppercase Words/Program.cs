using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> isIsUpperCase = x => char.IsUpper(x[0]);

            Console.WriteLine(string.Join(" \n ", words.Where(isIsUpperCase)));
        }
    }
}
