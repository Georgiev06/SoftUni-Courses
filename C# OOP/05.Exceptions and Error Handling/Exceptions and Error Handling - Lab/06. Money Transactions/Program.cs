using System;
using System.Collections.Generic;

namespace _06._Money_Transactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accounts = CreateDictionaryOfAccounts();
            
            var command = Console.ReadLine();

            while (command != "End")
            {
                var input = command.Split(' ');
                string commandType = input[0];
                int accountNumber = int.Parse(input[1]);
                double sum = double.Parse(input[2]);

                try
                {
                    if (commandType != "Deposit" && commandType != "Withdraw")
                    {
                        throw new InvalidOperationException("Invalid command!");
                    }
                    else if (!accounts.ContainsKey(accountNumber))
                    {
                        throw new InvalidOperationException("Invalid account!");
                    }
                    else if (commandType == "Withdraw" && accounts[accountNumber] - sum < 0)
                    {
                        throw new InvalidOperationException("Insufficient balance!");
                    }

                    if (commandType == "Deposit")
                    {
                        accounts[accountNumber] += sum;
                    }
                    else if (commandType == "Withdraw")
                    {
                        accounts[accountNumber] -= sum;
                    }

                    Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

                command = Console.ReadLine();
            }
        }

        private static Dictionary<int, double> CreateDictionaryOfAccounts()
        {
            string[] accounts = Console.ReadLine().Split(',');
            Dictionary<int, double> accountNumberAndBalance = new Dictionary<int, double>();

            foreach (var account in accounts)
            {
                string[] accountData = account.Split('-');
                int accountNumber = int.Parse(accountData[0]);
                double accountBalance = double.Parse(accountData[1]);

                accountNumberAndBalance[accountNumber] = accountBalance;
            }

            return accountNumberAndBalance;
        }
    }
}
