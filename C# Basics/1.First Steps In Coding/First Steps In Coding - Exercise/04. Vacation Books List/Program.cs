using System;

namespace _04._Vacation_Books_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPages = int.Parse(Console.ReadLine());
            int pages = int.Parse(Console.ReadLine());
            int numberOfDays = int.Parse(Console.ReadLine());

            int total = numberOfPages / pages;
            int numOfHours = total / numberOfDays;

            Console.WriteLine(numOfHours);
        }
    }
}
