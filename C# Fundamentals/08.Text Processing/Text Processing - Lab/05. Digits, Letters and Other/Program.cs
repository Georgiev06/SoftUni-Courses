using System;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder letters = new StringBuilder();    
            StringBuilder numbers = new StringBuilder();    
            StringBuilder otherChar = new StringBuilder();

            foreach (char item in text)
            {
                if (char.IsLetter(item))
                {
                    letters.Append(item);
                }
                else if (char.IsDigit(item))
                {
                    numbers.Append(item);
                }
                else
                {
                    otherChar.Append(item);
                }
            }

            Console.WriteLine(numbers.ToString());
            Console.WriteLine(letters.ToString());
            Console.WriteLine(otherChar.ToString());
        }
    }
}
