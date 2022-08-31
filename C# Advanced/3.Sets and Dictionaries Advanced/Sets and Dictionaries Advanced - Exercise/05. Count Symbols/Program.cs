using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            FillDictionary(symbols, input);
            PrintResult(symbols);
        }

        private static void PrintResult(SortedDictionary<char, int> symbols)
        {
            foreach (var kvp in symbols)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }

        private static SortedDictionary<char, int> FillDictionary(SortedDictionary<char, int> symbols, string input)
        {
            foreach (var symbol in input)
            {
                if (!symbols.ContainsKey(symbol))
                {
                    symbols.Add(symbol, 0);
                }
                symbols[symbol]++; 
            }
            return symbols;
        }
    }
}
