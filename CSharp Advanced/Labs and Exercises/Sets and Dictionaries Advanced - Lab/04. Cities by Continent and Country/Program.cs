using System;
using System.Collections.Generic;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                var inputsPatrs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var continents = inputsPatrs[0];
                var countries = inputsPatrs[1];
                var cities = inputsPatrs[2];

                if (!dict.ContainsKey(continents))
                {
                    dict[continents] = new Dictionary<string, List<string>>();
                }

                if (!dict[continents].ContainsKey(countries))
                {
                    dict[continents][countries] = new List<string>();
                }

                dict[continents][countries].Add(cities);
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}:");

                foreach (var kvp2 in kvp.Value)
                {
                    Console.WriteLine($"{kvp2.Key} -> {string.Join(", ", kvp2.Value)}");
                }
            }
        }
    }
}
