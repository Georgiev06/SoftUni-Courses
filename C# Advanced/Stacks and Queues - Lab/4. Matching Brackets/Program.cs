using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expresion = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expresion.Length; i++)
            {
                if (expresion[i] == '(')
                {
                    stack.Push(i);
                }

                if (expresion[i] == ')')
                {
                    int startIndex = stack.Pop();
                    int endIndex = i;
                    Console.WriteLine(expresion.Substring(startIndex, endIndex - startIndex + 1));
                }
            }

        }
    }
}
