using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace _02._Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var pattern = @"^[d-z{}|#]+$";
            var match = Regex.Match(text, pattern);

            if (match.Success)
            {
                var substringsInput = Console.ReadLine().Split(" ");
                var substring = substringsInput[0];
                var newString = substringsInput[1];

                var sb = new StringBuilder();

                for (int i = 0; i < text.Length; i++)
                {
                    var ChangedSymbol = (char)(text[i] - 3);
                    sb.Append(ChangedSymbol);
                }

                var changedText  = sb.ToString().Replace(substring, newString);
                Console.WriteLine(changedText);

            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
        }
    }
}
