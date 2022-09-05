using System;
using System.Linq;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printNames = names => Console.WriteLine(string.Join(Environment.NewLine, names));

            string[] name = Console.ReadLine().Split();

            printNames(name);
        }
    }
}
