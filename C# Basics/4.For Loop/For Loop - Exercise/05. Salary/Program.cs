using System;

namespace _05._Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int openTabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            int Facebook = 150;
            int Instagram = 100;
            int Reddit = 50;

            for (int i = 0; i <= openTabs; i++)
            {
                if (salary == 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }

                string nameOfTheWeb = Console.ReadLine();
                if (nameOfTheWeb == "Facebook")
                {
                    salary -= Facebook;
                }
                else if (nameOfTheWeb == "Instagram")
                {
                    salary -= Instagram;
                }
                else if (nameOfTheWeb == "Reddit")
                {
                    salary -= Reddit;
                }
            }

            if (salary > 0)
            {
                Console.WriteLine($"{salary}");
            }
        }
    }
}
