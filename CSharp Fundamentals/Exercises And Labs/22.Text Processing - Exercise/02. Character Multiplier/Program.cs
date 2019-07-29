using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ").ToArray();

            var firstString = input[0];
            var secondString = input[1];

            int totalSum = 0;

            if (firstString.Length > secondString.Length)
            {
                for (int i = 0; i < secondString.Length; i++)
                {
                    var fSymbol = firstString[i];
                    var sSymbol = secondString[i];

                    var multiplied = fSymbol * sSymbol;
                    totalSum += multiplied;
                }
                var lastSymbols = firstString.Substring(secondString.Length);

                for (int i = 0; i < lastSymbols.Length; i++)
                {
                    totalSum += lastSymbols[i];
                }
            }
            else if (secondString.Length > firstString.Length)
            {
                for (int i = 0; i < firstString.Length; i++)
                {
                    var multiplied = secondString[i] * firstString[i];
                    totalSum += multiplied;
                }

                var lastSymbols = secondString.Substring(firstString.Length);

                for (int i = 0; i < lastSymbols.Length; i++)
                {
                    totalSum += lastSymbols[i];
                }
            }
            else
            {
                for (int i = 0; i < firstString.Length; i++)
                {
                    var multiplied = secondString[i] * firstString[i];
                    totalSum += multiplied;
                }
            }
            Console.WriteLine(totalSum);
        }
    }
}
