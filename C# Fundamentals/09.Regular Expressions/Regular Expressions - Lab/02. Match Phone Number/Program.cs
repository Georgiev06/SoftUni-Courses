using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;


namespace _02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string regex = @"\+359( |-)2\1\d{3}\1\d{4}\b";

            string phones = Console.ReadLine();

            MatchCollection matches = Regex.Matches(phones, regex);
            List<string> result = new List<string>();

            foreach (Match item in matches)
            {
                result.Add(item.Value);
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
