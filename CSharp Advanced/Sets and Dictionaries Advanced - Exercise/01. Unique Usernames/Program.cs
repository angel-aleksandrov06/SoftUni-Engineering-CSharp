using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var inputName = Console.ReadLine();

                set.Add(inputName);
            }

            foreach (var name in set)
            {
                Console.WriteLine(name);
            }
        }
    }
}
