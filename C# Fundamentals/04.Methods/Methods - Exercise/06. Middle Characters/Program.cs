using System;

namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            MiddleCharacters(input);
        }
        static void MiddleCharacters(string input)
        {
            int len = input.Length;
            string result = "";

            if (len % 2 == 0)
            {
                result = input[input.Length / 2 - 1].ToString() + input[input.Length / 2].ToString();
                Console.WriteLine(result);
            }
            else
            {
                result = input[input.Length / 2].ToString();
                Console.WriteLine(result);
            }
        }
    }
}
