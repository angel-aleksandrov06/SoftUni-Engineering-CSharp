using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var pattern = @"^([$|%])(?<tag>[A-Z]{1}[a-z]{2,})\1: \[(?<firstChar>\d+)\]\|\[(?<secondChar>\d+)\]\|\[(?<thirdChar>\d+)\]\|$";

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                var match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    var sb = new StringBuilder();

                    var tag = match.Groups["tag"].ToString();
                    char firstChar = (char)(int.Parse(match.Groups["firstChar"].ToString()));
                    sb.Append(firstChar);
                    char secondChar = (char)(int.Parse(match.Groups["secondChar"].ToString()));
                    sb.Append(secondChar);
                    char thirdChar = (char)(int.Parse(match.Groups["thirdChar"].ToString()));
                    sb.Append(thirdChar);

                    Console.WriteLine($"{tag}: {sb.ToString()}");
                }
                else
                {
                    Console.WriteLine($"Valid message not found!");
                }
            }
        }
    }
}
