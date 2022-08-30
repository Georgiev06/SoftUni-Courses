using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    matrix[row] = matrix[row].Select(el => el * 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(el => el * 2).ToArray();
                }
                else
                {
                    matrix[row] = matrix[row].Select(el => el / 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(el => el / 2).ToArray();
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                int row = int.Parse(command.Split()[1]);
                int col = int.Parse(command.Split()[2]);
                int value = int.Parse(command.Split()[3]);

                if (command.StartsWith("Add"))
                {
                    //•	"Add {row} {column} {value}".Split => ["Add", "3", "1", "10"]                 
                    if (row >= 0 && row < rows && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] = matrix[row][col] + value;
                        //matrix[row][col] += value
                    }
                }
                else if (command.StartsWith("Subtract"))
                {
                    //•	"Subtract {row} {column} {value}"
                    if (row >= 0 && row < rows && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] = matrix[row][col] - value;
                        //matrix[row][col] -= value
                    }
                }



                command = Console.ReadLine();
            }

            foreach (int[] row in matrix)
            {
                //row -> int [3, 4, 5]
                Console.WriteLine(String.Join(' ', row));
            }
        }
    }
}
        
    

