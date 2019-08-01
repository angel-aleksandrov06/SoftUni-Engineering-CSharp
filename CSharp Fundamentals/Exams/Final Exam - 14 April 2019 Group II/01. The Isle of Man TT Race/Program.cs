using System;
using System.Text.RegularExpressions;
using System.Text;

namespace _03._The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"([#$%*&])(?<name>[A-Za-z]+)\1=(?<length>[0-9]+)!!(.*)$";

            var coordinatesFound = false;

            while (!coordinatesFound)
            {
                var input = Console.ReadLine();

                bool isMatched = Regex.IsMatch(input, pattern);

                if (isMatched)
                {
                    var match = Regex.Match(input, pattern);
                    var length = int.Parse(match.Groups["length"].ToString());

                    int index = int.Parse(input.IndexOf("!!").ToString());

                    var leftSymbols = input.Substring(index + 2);

                    if (leftSymbols.Length == length)
                    {
                        var name = match.Groups["name"].ToString();
                        var hashcode = leftSymbols;

                        var sb = new StringBuilder();

                        for (int i = 0; i < hashcode.Length; i++)
                        {
                            var result = (char)(hashcode[i] + length);
                            sb.Append(result);
                        }

                        Console.WriteLine($"Coordinates found! {name} -> {sb}");

                        coordinatesFound = true;
                    }
                }

                if (!coordinatesFound)
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
