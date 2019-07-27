using System;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+\b";

            string names = Console.ReadLine();

            MatchCollection MatchedNames = Regex.Matches(names, regex);

            foreach (Match match in MatchedNames)
            {
                Console.Write(match.Value + " ");
            }

            Console.WriteLine();
        }
    }
}
