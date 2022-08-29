using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool IsBalanced = true;

            Stack<char> stack = new Stack<char>();

            foreach (var item in input)
            {
                if (item == '{' || item == '[' || item == '(')
                {
                    stack.Push(item);
                    continue;
                }

                if (stack.Count == 0)
                {
                    IsBalanced = false;
                    break;
                }

                if (item == '}' && stack.Peek() == '{')
                {
                    stack.Pop();
                }
                else if (item == ']' && stack.Peek() == '[')
                {
                    stack.Pop();
                }
                else if (item == ')' && stack.Peek() == '(')
                {
                    stack.Pop();
                }
                else
                {
                    IsBalanced = false;
                    break;
                }
            }

            if (!IsBalanced || stack.Count > 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}