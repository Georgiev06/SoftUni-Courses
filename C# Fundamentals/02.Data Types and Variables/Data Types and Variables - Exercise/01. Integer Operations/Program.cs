using System;

namespace _01._Integer_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int tirthNum = int.Parse(Console.ReadLine());
            int fourthNum = int.Parse(Console.ReadLine());

            long firstOpperation = (long)firstNum + secondNum;
            long secondOpperation = firstOpperation / tirthNum;
            long tirthOpperation = secondOpperation * fourthNum;


            Console.WriteLine(tirthOpperation);
        }
    }
}
