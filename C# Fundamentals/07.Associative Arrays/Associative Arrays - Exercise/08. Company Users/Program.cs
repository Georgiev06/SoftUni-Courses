using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> companyInfo = new Dictionary<string, HashSet<string>>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string companyName = commandArgs[0];
                string employeeId = commandArgs[1];

                if (!companyInfo.ContainsKey(companyName))
                {
                    companyInfo.Add(companyName, new HashSet<string>());
                }

                //if (companyInfo.ContainsKey(employeeId) == companyInfo.ContainsKey(employeeId))
                //{
                //    companyInfo[companyName].Remove(employeeId);
                //}

                companyInfo[companyName].Add(employeeId);

            }

            foreach (var company in companyInfo)
            {
                string companyName = company.Key;
                HashSet<string> employees = company.Value;

                Console.WriteLine($"{companyName}");

                foreach (var employee in employees)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
