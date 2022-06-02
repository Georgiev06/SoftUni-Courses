using System;

namespace _06._Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfFloor = int.Parse(Console.ReadLine());
            int numOfRoom = int.Parse(Console.ReadLine());

            for (int floor = numOfFloor; floor >= 1; floor--)
            {
                for (int room = 0; room < numOfRoom; room++)
                {
                    if (floor == numOfFloor)
                    {
                        Console.Write($"L{floor}{room} ");
                        continue;
                    }

                    if (floor % 2 == 0)
                    {
                        Console.Write($"O{floor}{room} ");
                    }
                    else
                    {
                        Console.Write($"A{floor}{room} ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
