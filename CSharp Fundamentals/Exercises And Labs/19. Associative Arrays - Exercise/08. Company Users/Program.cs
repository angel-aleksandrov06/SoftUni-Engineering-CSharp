using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var dict = new SortedDictionary<string, List<string>>();

            while (input != "End")
            {
                var splitedInput = input.Split(" -> ");

                var name = splitedInput[0];
                var employeeID = splitedInput[1];


                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<string>());
                }

                if (!dict[name].Contains(employeeID))
                {
                    dict[name].Add(employeeID);
                }

                input = Console.ReadLine();
            }



            foreach (var item in dict)
            {
                Console.WriteLine(item.Key);

                foreach (var value in item.Value)
                {
                    Console.WriteLine($"-- {value}");
                }
            }
        }
    }
}
