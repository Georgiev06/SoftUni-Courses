using System;

namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string typeOfTheGroupe = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;

            if (typeOfTheGroupe == "Students")
            {
                if (day == "Friday")
                {
                    price = 8.45;
                    price *= countOfPeople;
                }
                else if (day == "Saturday")
                {
                    price = 9.80;
                    price *= countOfPeople;
                }
                else if (day == "Sunday")
                {
                    price = 10.46;
                    price *= countOfPeople;
                }

                if (countOfPeople >= 30)
                {
                    price *= 0.85;

                }
            }
            else if (typeOfTheGroupe == "Business")
            {
                if (day == "Friday")
                {
                    price = 10.90;
                    price *= countOfPeople;
                }
                else if (day == "Saturday")
                {
                    price = 15.60;
                    price *= countOfPeople;
                }
                else if (day == "Sunday")
                {
                    price = 16;
                    price *= countOfPeople;
                }

                if (countOfPeople >= 100)
                {
                    price -= 10 * (price / countOfPeople);
                }
            }
            else if (typeOfTheGroupe == "Regular")
            {
                if (day == "Friday")
                {
                    price = 15;
                    price *= countOfPeople;
                }
                else if (day == "Saturday")
                {
                    price = 20;
                    price *= countOfPeople;
                }
                else if (day == "Sunday")
                {
                    price = 22.50;
                    price *= countOfPeople;
                }

                if (countOfPeople >= 10 && countOfPeople <= 20)
                {
                    price *= 0.95;
                }
            }
            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
