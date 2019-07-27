using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> racers = input.Split(", ").ToList();
            Dictionary<string, int> race = new Dictionary<string, int>();

            foreach (var racer in racers)
            {
                if (!race.ContainsKey(racer))
                {
                    race.Add(racer, 0);
                }
            }

            input = Console.ReadLine();
            string pattern = @"[\w]";


            while (input != "end of race")
            {
                MatchCollection matches = Regex.Matches(input, pattern);

                string symbols = "";

                foreach (Match match in matches)
                {
                    symbols += match;
                }

                string letter = string.Empty;
                int digits = 0;

                for (int i = 0; i < symbols.Length; i++)
                {
                    if (Char.IsLetter(symbols[i]))
                    {
                        string curentLetter = symbols[i].ToString();
                        letter += curentLetter;
                    }
                    else
                    {
                        string symbol = symbols[i].ToString();
                        int digit = int.Parse(symbol);
                        digits += digit;
                    }
                }

                foreach (var key in race)
                {
                    if (race.ContainsKey(letter))
                    {
                        race[letter] += digits;
                        break;
                    }
                }


                input = Console.ReadLine();
            }

            var ordered = race.OrderByDescending(x => x.Value);

            int count = 0;
            string firstRacer = "";
            string secondRacer = "";
            string thirdRacer = "";

            foreach (var kvp in ordered)
            {
                count++;
                if (count == 1)
                {
                    firstRacer = kvp.Key;
                }
                if (count == 2)
                {
                    secondRacer = kvp.Key;
                }
                if (count == 3)
                {
                    thirdRacer = kvp.Key;
                }
            }

            Console.WriteLine($"1st place: {firstRacer}");
            Console.WriteLine($"2nd place: {secondRacer}");
            Console.WriteLine($"3rd place: {thirdRacer}");
        }
    }
}
