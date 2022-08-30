using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] rowInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            int sum = 0;

            for (int row = 0; row < n; row++)
            {
                 sum += matrix[row, row];       
            }

            Console.WriteLine(sum);
        }
    }
}
