using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                var name = input[0];
                var age = int.Parse(input[1]);

                if (!dict.ContainsKey(name))
                {
                    dict[name] = age;
                }
            }

            var condition = Console.ReadLine();
            var conditionAge = int.Parse(Console.ReadLine());

            var filteredDict = new Dictionary<string, int>();

            if (condition == "older")
            {
                foreach (var kvp in dict)
                {
                    if (kvp.Value >= conditionAge)
                    {
                        filteredDict.Add(kvp.Key,kvp.Value);
                    }
                }
            }
            else if (condition == "younger")
            {
                foreach (var kvp in dict)
                {
                    if (kvp.Value < conditionAge)
                    {
                        filteredDict.Add(kvp.Key, kvp.Value);
                    }
                }
            }

            var format = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (format.Length > 1)
            {
                if (format[0] == "name")
                {
                    foreach (var kvp in filteredDict)
                    {
                        Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                    }
                }
                else if (format[0] == "age")
                {
                    foreach (var kvp in filteredDict)
                    {
                        Console.WriteLine($"{kvp.Value} - {kvp.Key}");
                    }
                }
            }
            else
            {
                if (format[0] == "name")
                {
                    foreach (var kvp in filteredDict)
                    {
                        Console.WriteLine($"{kvp.Key}");
                    }
                }
                else if (format[0] == "age")
                {
                    foreach (var kvp in filteredDict)
                    {
                        Console.WriteLine($"{kvp.Value}");
                    }
                }
            }

        }
    }
}
