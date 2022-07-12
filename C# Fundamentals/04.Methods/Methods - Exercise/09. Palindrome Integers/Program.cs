using System;

namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while (command != "END")
            {
                PalindromeIntegers(command);

                command = Console.ReadLine();
            }

        }
        static void PalindromeIntegers(string command)
        {
            string reversed = "";

            for (int j = command.Length - 1; j >= 0; j--)
            {
                reversed += command[j];
            }

            if (command == reversed)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}


