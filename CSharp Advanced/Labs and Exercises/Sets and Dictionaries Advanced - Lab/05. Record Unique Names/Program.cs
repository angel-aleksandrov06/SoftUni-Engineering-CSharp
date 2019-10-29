using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                set.Add(Console.ReadLine());
            }

            foreach (var name in set)
            {
                Console.WriteLine(name);
            }
        }
    }
}
