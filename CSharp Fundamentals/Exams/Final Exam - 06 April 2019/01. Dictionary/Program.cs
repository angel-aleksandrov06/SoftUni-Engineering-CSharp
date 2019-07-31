using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace _01._Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var wodrsAndDefinitions = Console.ReadLine().Split(" | ");

            var dict = new Dictionary<string, List<string>>();

            foreach (var item in wodrsAndDefinitions)
            {
                var splitedItems = item.Split(": ");

                var word = splitedItems[0];
                var definition = splitedItems[1];

                if (!dict.ContainsKey(word))
                {
                    dict[word] = new List<string>();
                }

                dict[word].Add(definition);
            }

            var inputCheckers = Console.ReadLine().Split(" | ");

            foreach (var checker in inputCheckers)
            {
                if (dict.ContainsKey(checker))
                {
                    Console.WriteLine($"{checker}");

                    foreach (var item in dict[checker].OrderByDescending(x => x.Length))
                    {
                        Console.WriteLine($" -{item}");
                    }
                }
            }

            var command = Console.ReadLine();

            if (command == "End")
            {
                return;
            }
            else if (command == "List")
            {
                Console.WriteLine(string.Join(" ", dict.Keys.OrderBy(x => x)));

            }
        }
    }
}
