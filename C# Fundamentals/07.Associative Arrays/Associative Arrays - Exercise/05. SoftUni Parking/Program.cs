using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkingRegister = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string commandType = commandArgs[0];
                string userName = commandArgs[1];

                if (commandType == "register")
                {
                    string licensePlateNumber = commandArgs[2];

                    RegisterUser(parkingRegister, userName, licensePlateNumber);
                }
                else if (commandType == "unregister")
                {
                    UnregisterUser(parkingRegister, userName);
                }

            }

            foreach (var keyValuePair in parkingRegister)
            {
                Console.WriteLine($"{keyValuePair.Key} => {keyValuePair.Value}");
            }
        }

        static void RegisterUser(Dictionary<string, string> parkingRegister, string userName, string licensePlateNumber)
        {
            if (parkingRegister.ContainsKey(userName))
            {
                string licensePlateNumberRegistered = parkingRegister[userName];

                Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumberRegistered}");
            }
            else
            {
                parkingRegister[userName] = licensePlateNumber;
                Console.WriteLine($"{userName} registered {licensePlateNumber} successfully");
            }
        }

        static void UnregisterUser(Dictionary<string, string> parkingRegister, string userName)
        {
            if (!parkingRegister.ContainsKey(userName))
            {
                Console.WriteLine($"ERROR: user {userName} not found");
            }
            else
            {
                parkingRegister.Remove(userName);
                Console.WriteLine($"{userName} unregistered successfully");
            }
        }
    }
}
