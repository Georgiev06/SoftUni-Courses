using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                string[] splittedCommand = command.Split();

                string commandType = splittedCommand[0];

                if (commandType == "add")
                {
                    int firstNum = int.Parse(splittedCommand[1]);
                    int secondNum = int.Parse(splittedCommand[2]);
                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }

                if (commandType == "remove")
                {
                    int count = int.Parse(splittedCommand[1]);

                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                command = Console.ReadLine().ToLower();
            }
            int sum = 0;

            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }


            Console.WriteLine($"Sum: {sum}");
        }
    }
}
