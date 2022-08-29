using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] clothingValue = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int capacityOfARack = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(clothingValue);

            int countOfRacks = 1;
            int sumOfClothes = 0;

            for (int i = 0; i < clothingValue.Length; i++)
            {
                int currentClothing = stack.Peek();

                if (sumOfClothes + currentClothing <= capacityOfARack)
                {
                    sumOfClothes += currentClothing;
                    stack.Pop();

                    if (sumOfClothes == capacityOfARack && stack.Count != 0)
                    {
                        countOfRacks++;
                        sumOfClothes = 0;
                    }
                }
                else
                {
                    i--;
                    countOfRacks++;
                    sumOfClothes = 0;
                }
            }

            Console.WriteLine(countOfRacks);
        }
    }
}
