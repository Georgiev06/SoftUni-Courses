﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            Dictionary <double, int> numberOccurrences = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!numberOccurrences.ContainsKey(number))
                {
                    numberOccurrences.Add(number, 0);            
                }
                numberOccurrences[number]++;
            }

            foreach (var occurrence in numberOccurrences)
            {
                Console.WriteLine($"{occurrence.Key} - {occurrence.Value} times");
            }
        }
    }
}
