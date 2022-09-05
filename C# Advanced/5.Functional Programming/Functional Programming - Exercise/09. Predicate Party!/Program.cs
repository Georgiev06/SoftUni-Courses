using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> names = Console.ReadLine().Split().ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] splittedCommand = command.Split();

                string input = splittedCommand[0];
                string operation = splittedCommand[1];
                string value = splittedCommand[2];

                if (input == "Double")
                {
                   List<string> doubledNames = names.FindAll(GetPredicate(operation, value));

                    if (!doubledNames.Any())
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    int index = names.FindIndex(GetPredicate(operation, value));

                    names.InsertRange(index, doubledNames);
                }
                else
                {
                    names.RemoveAll(GetPredicate(operation, value));
                }

                command = Console.ReadLine();
            }

            if (names.Any())
            {
                Console.WriteLine($"{String.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string operation, string value)
        {
            if (operation == "StartsWith")
            {
                return x => x.StartsWith(value);
            }

            if (operation == "EndsWith")
            {
                return x => x.EndsWith(value);
            }

            int valueAsInt = int.Parse(value);

            return x => x.Length == valueAsInt;
        }
    }
}
