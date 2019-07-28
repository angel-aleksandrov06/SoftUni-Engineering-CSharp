using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<char, int>();

            string someText = Console.ReadLine();

            for (int i = 0; i < someText.Length; i++)
            {
                char symbol = someText[i];

                if (symbol !=' ')
                {
                    if (!dict.ContainsKey(symbol))
                    {
                        dict.Add(symbol, 0);
                    }

                    dict[symbol]++;
                }

            }
                foreach (var item in dict)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
        }
    }
}
