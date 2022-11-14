using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyerList = new Dictionary<string, IBuyer>();
            IBuyer buyer = null;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];

                if (input.Length == 4)
                {
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];

                    buyer = new Citizen(name, age, id, birthdate);
                }
                else if (input.Length == 3)
                {
                    int age = int.Parse(input[1]);
                    string group = input[2];

                    buyer = new Rebel(name, age, group);
                }

                buyerList[name] = buyer;
            }

            string buyerName = Console.ReadLine();

            while (buyerName != "End")
            {
                if (buyerList.ContainsKey(buyerName))
                {
                    buyerList[buyerName].BuyFood();
                }

                buyerName = Console.ReadLine();
            }

            int boughtFood = buyerList.Values.Sum(x => x.Food);
            Console.WriteLine(boughtFood);
        }
    }
}
