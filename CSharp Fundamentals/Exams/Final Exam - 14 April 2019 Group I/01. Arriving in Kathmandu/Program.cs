using System;
using System.Text.RegularExpressions;
using System.Text;

namespace _01._Arriving_in_Kathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"^(?<peak>[A-Za-z0-9!@#$?]+)=(?<length>\d+)<<(?<hash>(.*?)+)$";

            while (input != "Last note")
            {
                var match = Regex.Match(input, pattern);
                var isLengthValid = false;

                if (match.Success)
                {
                    var nameofMountain = match.Groups["peak"].ToString();
                    var length = int.Parse(match.Groups["length"].ToString());
                    var hash = match.Groups["hash"].ToString();

                    if (length == hash.Length)
                    {
                        isLengthValid = true;

                        var sb = new StringBuilder();

                        for (int i = 0; i < nameofMountain.Length; i++)
                        {
                            if (char.IsLetterOrDigit(nameofMountain[i]))
                            {
                                sb.Append(nameofMountain[i]);
                            }
                        }
                        nameofMountain = sb.ToString();

                        Console.WriteLine($"Coordinates found! {nameofMountain} -> {hash}");
                    }
                }
                if (isLengthValid == false)
                {
                    Console.WriteLine("Nothing found!");
                }

                input = Console.ReadLine();
            }
        }
    }
}
