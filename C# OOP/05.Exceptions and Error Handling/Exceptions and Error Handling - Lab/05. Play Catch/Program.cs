using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Play_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int countOfExceptions = 0;

            while (countOfExceptions != 3)
            {
                string[] command = Console.ReadLine().Split();
                string commandType = command[0];

                try
                {
                    if (commandType == "Replace")
                    {
                        int index = int.Parse(command[1]);
                        int element = int.Parse(command[2]);

                        numbers[index] = element;
                    }
                    else if (commandType == "Print")
                    {
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);

                        var nums = new List<int>(); 

                        for (int i = startIndex; i <= endIndex; i++)
                        {
                           nums.Add(numbers[i]);
                        }

                        Console.WriteLine(String.Join(", ", nums));
                    }
                    else if (commandType == "Show")
                    {
                        int index = int.Parse(command[1]);
                        Console.WriteLine(numbers[index]);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    countOfExceptions++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    countOfExceptions++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
