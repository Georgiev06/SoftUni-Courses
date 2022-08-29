using System;
using System.Collections.Generic;

namespace _01._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (var symbol in input)
            {
                stack.Push(symbol);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

        }
    }
}