using System;

namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double currentMoney = double.Parse(Console.ReadLine());
            int dayscounter = 0;
            int spendingCounter = 0;

            while (spendingCounter != 5)
            {
                string command = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                dayscounter++;
                if (command == "save")
                {
                    currentMoney += money;
                    spendingCounter = 0;
                }

                else if (command == "spend")
                {
                    if (money > currentMoney)
                    {
                        currentMoney = 0;
                    }
                    else
                    {
                        currentMoney -= money;
                    }
                    spendingCounter++;
                }

                if (currentMoney >= neededMoney)
                {
                    Console.WriteLine($"You saved the money for {dayscounter} days.");
                    break;
                }
            }

            if (spendingCounter == 5)
            {
                Console.WriteLine($"You can't save the money.");
                Console.WriteLine(dayscounter);
            }
        }
    }
}
