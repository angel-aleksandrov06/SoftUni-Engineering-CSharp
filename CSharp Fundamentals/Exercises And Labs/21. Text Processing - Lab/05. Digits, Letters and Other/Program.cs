using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var lettersSymbols = new StringBuilder();
            var digitSymbols = new StringBuilder();
            var otherSymbols = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]))
                {
                    lettersSymbols.Append(input[i]);
                }
                else if (Char.IsDigit(input[i]))
                {
                    digitSymbols.Append(input[i]);
                }
                else if (!Char.IsLetterOrDigit(input[i]))
                {
                    otherSymbols.Append(input[i]);
                }
            }

            Console.WriteLine(digitSymbols.ToString());
            Console.WriteLine(lettersSymbols.ToString());
            Console.WriteLine(otherSymbols.ToString());
        }
    }
}
