    using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> IsLessOrEqual = (name, lenght) => name.Length <= lenght;

            string[] result = names.Where(x => IsLessOrEqual(x, n)).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
