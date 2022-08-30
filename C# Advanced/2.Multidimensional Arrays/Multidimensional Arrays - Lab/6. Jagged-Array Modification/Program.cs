using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jagged[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] splitedCommand = command.Split();

                int row = int.Parse(splitedCommand[1]);
                int col = int.Parse(splitedCommand[2]);
                int value = int.Parse(splitedCommand[3]);

                if (row < 0 || col < 0 || row >= jagged.Length || col >= jagged[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (splitedCommand[0] == "Add")
                {
                    jagged[row][col] += value;
                }
                else if (splitedCommand[0] == "Subtract")
                {
                    jagged[row][col] -= value;
                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine($"{string.Join(" ", jagged[row])}");
            }
        }
    }
}
