using System;

namespace _01._Old_Books
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string searchedBook = Console.ReadLine();
            int countedBooks = 0;
            string currentBook = Console.ReadLine();

            while (currentBook != "No More Books")
            {
                if (currentBook == searchedBook)
                {
                    Console.WriteLine($"You checked {countedBooks} books and found it.");
                    break;
                }

                countedBooks++;
                currentBook = Console.ReadLine();
            }

            if (currentBook == "No More Books")
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {countedBooks} books.");
            }
        }
    }
}
