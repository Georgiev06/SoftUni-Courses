using System;

namespace _04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string cipher = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                ch += (char)3;
                cipher += ch;
            }

            Console.WriteLine(cipher);
        }
    }
}
