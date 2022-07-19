using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();

            string command;

            while ((command = Console.ReadLine()) != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(command))
                {
                    resources[command] += quantity;
                }
                else
                {
                    resources.Add(command, quantity);
                }
            }

            foreach (var keyValuePair in resources)
            {
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value}");
            }
        }
    }
}
