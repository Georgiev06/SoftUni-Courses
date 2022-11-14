using System;
using System.Linq;

namespace ListIterator
{
    internal class StartUp
    {
        static void Main(string[] args)
        {

            string command = "";
            ListyIterator<string> listy = null;

            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split();

                if (tokens[0] == "Create")
                {
                    listy = new ListyIterator<string>(tokens.Skip(1).ToArray());
                }
                else if (tokens[0] == "Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if (tokens[0] == "Print")
                {
                    listy.Print();
                }
                else if (tokens[0] == "PrintAll")
                {
                    listy.PrintAll();
                }
                else if (tokens[0] == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }
            }
        }
    }
}
