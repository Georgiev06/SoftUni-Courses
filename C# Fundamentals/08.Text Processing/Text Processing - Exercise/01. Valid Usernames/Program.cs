using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            List<string> validUserNames = new List<string>();

            for (int i = 0; i < userNames.Length; i++)
            {
                string user = userNames[i];
                if (user.Length >= 3 && user.Length <= 16)
                {
                    bool validUsernames = ValidUserNames(user);
                    if (validUsernames == true)
                    {
                        validUserNames.Add(user);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, validUserNames));
        }

        private static bool ValidUserNames(string user)
        {
            foreach (var symbol in user)
            {
                if (char.IsLetterOrDigit(symbol) || symbol == '-' || symbol == '_')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
