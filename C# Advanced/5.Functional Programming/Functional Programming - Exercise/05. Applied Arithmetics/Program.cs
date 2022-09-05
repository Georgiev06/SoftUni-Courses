using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            Action<int[]> addNumber = x =>
            {
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] += 1;
                }
            };
            
            Action<int[]> subtractNumber = x =>
            {
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] -= 1;
                }
            };
            
            Action<int[]> multiplyNumber = x =>
            {
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] *= 2;
                }
            };

            Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));

            while (command != "end")
            {
                if (command == "add")
                {
                    addNumber(numbers);
                }
                else if (command == "subtract")
                {
                    subtractNumber(numbers);
                }
                else if (command == "multiply")
                {
                    multiplyNumber(numbers);
                }
                else if (command == "print")
                {
                    print(numbers);
                }
                
                command = Console.ReadLine();
            }
        }
    }
}
