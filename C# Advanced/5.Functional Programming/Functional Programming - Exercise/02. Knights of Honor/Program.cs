using System;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printNames = names => Console.WriteLine("Sir " + string.Join(Environment.NewLine + "Sir ", names));

            string[] name = Console.ReadLine().Split();

            printNames(name);
        }
    }
}
