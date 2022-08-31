using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string currentUsername = Console.ReadLine();
                usernames.Add(currentUsername);
            }

            foreach (string username in usernames)
            {
                Console.WriteLine(username);
            }

        }
    }
}
