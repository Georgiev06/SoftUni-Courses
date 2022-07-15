using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "Delete")
                {
                    int numberToDelete = int.Parse(tokens[1]);
                    numbers.Remove(numberToDelete);
                }
                else if (tokens[0] == "Insert")
                {
                    int elementToInsert = int.Parse(tokens[1]);
                    int indexToInsertAt = int.Parse(tokens[2]);
                    numbers.Insert(indexToInsertAt, elementToInsert);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }

    }
}
