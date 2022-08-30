using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];


            for (int row = 0; row < n; row++)
            {
                int currColumn = 0;
                string value = Console.ReadLine();
                foreach (char ch in value)
                {
                    matrix[row, currColumn] = ch;
                    currColumn++;
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    if (matrix[row, column] == symbol)
                    {
                        Console.WriteLine($"({row}, {column})");
                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix ");
        }
    }
}
