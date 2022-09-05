
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

            Dictionary<string, Predicate<string>> allFilters = new Dictionary<string, Predicate<string>>();

            while (command != "Print")
            {
                string[] splittedCommand = command.Split(';');

                string input = splittedCommand[0];
                string operation = splittedCommand[1];
                string value = splittedCommand[2];

                if (input == "Add filter")
                {
                    allFilters.Add(operation + value, GetPredicate(operation, value));
                }
                else
                {
                    allFilters.Remove(operation + value);
                }

                command = Console.ReadLine();
            }

            foreach (var (key, value) in allFilters)
            {
                names.RemoveAll(value);
            }

            Console.WriteLine(String.Join(" ", names));
        }

        private static Predicate<string> GetPredicate(string operation, string value)
        {
            if (operation == "Starts with")
            {
                return x => x.StartsWith(value);
            }

            if (operation == "Ends with")
            {
                return x => x.EndsWith(value);
            }

            if (operation == "Contains")
            {
                return x => x.Contains(value);
            }

            int valueAsInt = int.Parse(value);

            return x => x.Length == valueAsInt;
        }
    }
}
    

