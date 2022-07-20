using System;

namespace _03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine();
            string text = Console.ReadLine();

            while (text.Contains(wordToRemove))
            {
                int indexOfWordToRemove = text.IndexOf(wordToRemove);
                text = text.Remove(indexOfWordToRemove, wordToRemove.Length);
            }

            Console.WriteLine(text);
        }
    }
}
