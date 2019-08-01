using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _02._Practice_Sessions
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var dict = new SortedDictionary<string, List<string>>();

            while (input != "END")
            {
                var splitedInput = input.Split("->");
                var command = splitedInput[0];


                if (command == "Add")
                {
                    var road = splitedInput[1];
                    var racer = splitedInput[2];

                    if (!dict.ContainsKey(road))
                    {
                        dict[road] = new List<string>();
                    }

                    dict[road].Add(racer);
                }
                else if (command == "Move")
                {
                    var currentRoad = splitedInput[1];
                    var racer = splitedInput[2];
                    var nextRoad = splitedInput[3];

                    if (dict[currentRoad].Contains(racer))
                    {
                        dict[nextRoad].Add(racer);
                        dict[currentRoad].Remove(racer);
                    }

                }
                else if (command == "Close")
                {
                    var road = splitedInput[1];

                    if (dict.ContainsKey(road))
                    {
                        dict.Remove(road);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Practice sessions:");
            foreach (var road in dict.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{road.Key}");

                foreach (var racer in road.Value)
                {
                    Console.WriteLine($"++{racer}");
                }
            }
        }
    }
}
