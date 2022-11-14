using System;
using System.Collections.Generic;

namespace _02._Enter_Numbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int start = 1;

            while (numbers.Count != 10)
            {
                int end = 100;

                try
                {
                    start = ReadNumber(start, end);
                    numbers.Add(start);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        public static int ReadNumber(int start, int end)
        {
            string number = Console.ReadLine();

            if (!int.TryParse(number, out int result))
            {
                throw new FormatException("Invalid Number!");
            }

            if (result <= start || result >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - 100!");
            }

            return result;
        }
    }
}
