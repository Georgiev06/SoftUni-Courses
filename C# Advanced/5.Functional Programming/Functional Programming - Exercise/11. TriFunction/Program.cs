using System;
using System.Linq;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> IsLargerOrEqual = (name, sum) => name.Sum(x => x) >= sum;

            Func<string[], int, Func<string, int, bool>, string> getName = (names, assci, func) => names.Where(x => func(x, assci)).FirstOrDefault();

           var name = getName(names, sum, IsLargerOrEqual);
            Console.WriteLine(name);
        }
    }
}
