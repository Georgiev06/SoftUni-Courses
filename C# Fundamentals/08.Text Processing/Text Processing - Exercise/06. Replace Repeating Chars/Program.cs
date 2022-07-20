using System;


namespace _06._Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length - 1; i++)
            {
                char currentLetter = text[i];
                char nextLetter = text[i + 1];

                if (currentLetter == nextLetter)
                {
                    text = text.Remove(i, 1);
                    i--;
                }
            }

            Console.WriteLine(text);
        }
    }
}
