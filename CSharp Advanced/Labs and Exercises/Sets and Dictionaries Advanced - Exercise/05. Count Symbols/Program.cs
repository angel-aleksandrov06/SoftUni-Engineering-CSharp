using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var dict = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                var inputChar = input[i];

                if (!dict.ContainsKey(inputChar))
                {
                    dict[inputChar] = 0;
                }

                dict[inputChar]++;
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
