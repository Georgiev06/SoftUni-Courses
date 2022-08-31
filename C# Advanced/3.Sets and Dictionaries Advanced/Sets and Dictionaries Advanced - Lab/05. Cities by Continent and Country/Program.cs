using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> map = new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = input[0];
                string country = input[1];
                string city = input[2]; 

                if (!map.ContainsKey(continent))
                {
                    map[continent] = new Dictionary<string, List<string>>();
                }

                if (!map[continent].ContainsKey(country))
                {
                    map[continent].Add(country, new List<string>());
                }
                
                map[continent][country].Add(city);
            }

            foreach (var continent in map)
            {
                var continentName = continent.Key;
                var countries = continent.Value;

                Console.WriteLine($"{continentName}:");
                foreach (var country in countries)
                {
                    var cities = country.Value;

                    Console.WriteLine($" {country.Key} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
