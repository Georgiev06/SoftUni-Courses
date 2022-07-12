using System;

namespace _03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstChar = char.Parse(Console.ReadLine());
            int secondChar = char.Parse(Console.ReadLine());
            CharactersInRange(firstChar, secondChar);
        }

        static void CharactersInRange(int firstChar, int secondChar)
        {
            int IndexCharOne = Math.Min(firstChar, secondChar);
            int IndexCharTwo = Math.Max(firstChar, secondChar);

            for (int i = IndexCharOne + 1; i < IndexCharTwo; i++)
            {
                Console.Write($"{(char)i} ");
            }

            //if (IndexCharTwo < IndexCharOne)
            //{
            //    IndexCharTwo = firstChar;
            //    IndexCharOne = secondChar;
            //}

            Console.WriteLine();
        }
    }
}
