using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<long, int>();

            for (int i = 0; i < n; i++)
            {
                var input = long.Parse(Console.ReadLine());

                if (!dict.ContainsKey(input))
                {
                    dict[input] = 0;
                }

                dict[input] += 1;
            }

            foreach (var item in dict)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }

        }
    }
}
