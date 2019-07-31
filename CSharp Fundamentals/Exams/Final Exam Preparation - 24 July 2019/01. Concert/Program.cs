using System;
using System.Linq;
using System.Collections.Generic;


namespace _01._Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var dict = new Dictionary<string, List<string>>();
            var timeGroup = new Dictionary<string, int>();

            while (input != "start of concert")
            {
                var splitedInput = input.Split("; ");

                var command = splitedInput[0];
                var bandName = splitedInput[1];
                var leftInput = splitedInput[2];

                if (command == "Add")
                {
                    var nameOfPlayrs = leftInput.Split(", ");

                    if (!dict.ContainsKey(bandName))
                    {
                        dict[bandName] = new List<string>();
                    }

                    foreach (var item in nameOfPlayrs)
                    {
                        if (!dict[bandName].Contains(item))
                        {
                            dict[bandName].Add(item);
                        }
                    }
                }
                else if (command == "Play")
                {
                    var time = int.Parse(leftInput);

                    if (!dict.ContainsKey(bandName))
                    {
                        dict[bandName] = new List<string>();
                    }

                    if (!timeGroup.ContainsKey(bandName))
                    {
                        timeGroup[bandName] = 0;
                    }

                    timeGroup[bandName] += time;
                }

                input = Console.ReadLine();
            }

            var finalInput = Console.ReadLine();

            var totalTime = timeGroup.Values.Sum();
            Console.WriteLine($"Total time: {totalTime}");

            var orderedByTime = timeGroup.OrderByDescending(x => x.Value).ThenBy(x=>x.Key);

            foreach (var item in orderedByTime)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

            Console.WriteLine($"{finalInput}");

            foreach (var item in dict[finalInput])
            {
                Console.WriteLine($"=> {item}");
            }
        }
    }
}
