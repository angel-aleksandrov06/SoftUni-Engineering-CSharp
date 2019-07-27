using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var replacedSymbols = new StringBuilder();

            char[] charArr = input.ToCharArray();

            for (int i = 0; i < charArr.Length; i++)
            {
                int theSymbolsNumber = charArr[i] +3;
                char newSymbol = (char)theSymbolsNumber;

                replacedSymbols.Append(newSymbol);
            }

            Console.WriteLine(replacedSymbols);
        }
    }
}
