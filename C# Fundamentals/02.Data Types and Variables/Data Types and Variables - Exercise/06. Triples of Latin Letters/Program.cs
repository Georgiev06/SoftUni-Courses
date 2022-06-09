using System;

namespace _06._Triples_of_Latin_Letters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 97; i < 97 + n; i++)
            {
                for (int k = 97; k < 97 + n; k++)
                {
                    for (int j = 97; j < 97 + n; j++)
                    {
                        Console.WriteLine($"{(char)i}{(char)k}{(char)j}");
                    }
                }
            }
        }
    }
}
