using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._On_the_Way_to_Annapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var dict = new Dictionary<string, List<string>>();

            while (input != "END")
            {
                var splitedInput = input.Split("->");
                var command = splitedInput[0];
                var store = splitedInput[1];

                if (command == "Add")
                {
                    var items = splitedInput[2].Split(",");

                    if (!dict.ContainsKey(store))
                    {
                        dict[store] = new List<string>();
                    }

                    foreach (var item in items)
                    {
                        dict[store].Add(item);
                    }
                }
                else if (command == "Remove")
                {
                    if (dict.ContainsKey(store))
                    {
                        dict.Remove(store);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Stores list:");

            foreach (var item in dict.OrderByDescending(x=>x.Value.Count).ThenByDescending(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}");
                foreach (var thinks in item.Value)
                {
                    Console.WriteLine($"<<{thinks}>>");
                }
            }
        }
    }
}
