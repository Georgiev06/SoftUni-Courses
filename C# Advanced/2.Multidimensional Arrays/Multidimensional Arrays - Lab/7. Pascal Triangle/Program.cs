using System;

namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long[][] jagged = new long[n][];
            jagged[0] = new long[1] { 1 };

            for (int row = 1; row < n; row++)
            {
                jagged[row] = new long[jagged[row - 1].Length + 1];

                for (int col = 0; col < jagged[row].Length; col++)
                {
                    if (jagged[row - 1].Length > col)
                    {
                        jagged[row][col] += jagged[row - 1][col];
                    }
                    if (col > 0)
                    {
                        jagged[row][col] += jagged[row - 1][col - 1];
                    }
                }
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine($"{string.Join(" ", jagged[row])}");
            }
        }
    }
}
