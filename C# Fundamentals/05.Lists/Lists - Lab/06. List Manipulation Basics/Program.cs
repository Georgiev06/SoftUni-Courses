using System;
using System.Collections.Generic;
using System.Linq;

namespace Lists___Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Reading List Values from a Single Line

            List<int> items = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] line = command.Split(" ");
                string action = line[0];

                if (action == "Add")
                {
                    int itemToAdd = int.Parse(line[1]);
                    items.Add(itemToAdd);
                }
                else if (action == "Remove")
                {
                    int itemToRemove = int.Parse(line[1]);
                    items.Remove(itemToRemove);
                }
                else if (action == "RemoveAt")
                {
                    int itemToRemoveAt = int.Parse(line[1]);
                    items.RemoveAt(itemToRemoveAt);
                }
                else if (action == "Insert")
                {
                    int num = int.Parse(line[1]);
                    int index = int.Parse(line[2]);
                    items.Insert(index, num);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", items));
        }
    }
}
