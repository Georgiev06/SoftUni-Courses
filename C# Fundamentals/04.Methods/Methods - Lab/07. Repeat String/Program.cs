using System;
using System.Text;

namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repeatTimes = int.Parse(Console.ReadLine());
            string result = RepeatStrings(input, repeatTimes);
            Console.WriteLine(result);

        }

        static string RepeatStrings(string input, int repeatTimes)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < repeatTimes; i++)
            {
                result.Append(input);
            }

            return result.ToString();

        }
    }
}