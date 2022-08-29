using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            Stack<string> stack = new Stack<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(' ');

                string commandType = commandArgs[0];

                if (commandType == "1")
                {
                    stack.Push(sb.ToString());
                    string text = commandArgs[1];
                    sb.Append(text);
                }
                else if (commandType == "2")
                {
                    stack.Push(sb.ToString());
                    int count = int.Parse(commandArgs[1]);
                    sb.Remove(sb.Length - count, count);
                }
                else if (commandType == "3")
                {
                    int index = int.Parse(commandArgs[1]);
                    Console.WriteLine(sb[index - 1]);
                }
                else if (commandType == "4")
                {
                    sb = new StringBuilder(stack.Pop());
                }

            }
        }
    }
}
