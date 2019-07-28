using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ")
                .ToArray();

            var counts = new Dictionary<string, int>();

            foreach (var item in input)
            {
                string currentItem = item.ToLower();

                if (!counts.ContainsKey(currentItem))
                {
                    counts.Add(currentItem, 0);
                }

                counts[currentItem]++;
                
            }

            foreach (var item in counts)
            {
                if(item.Value % 2 != 0)
                {
                    Console.Write(item.Key+ " ");
                }
            }
        }
    }
}
