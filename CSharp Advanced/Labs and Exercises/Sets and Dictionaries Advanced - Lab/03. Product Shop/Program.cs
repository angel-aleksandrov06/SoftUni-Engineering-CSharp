using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();

            var dict = new Dictionary<string, Dictionary<string, double>>();

            while (command != "Revision")
            {
                var commandParts = command.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var nameOfShop = commandParts[0];
                var nameOFFood = commandParts[1];
                var price = double.Parse(commandParts[2]);

                if (!dict.ContainsKey(nameOfShop))
                {
                    dict[nameOfShop] = new Dictionary<string, double>();
                }

                dict[nameOfShop][nameOFFood] = price;

                command = Console.ReadLine();
            }

            foreach (var kvp in dict.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}->");
                foreach (var kvp2 in kvp.Value)
                {
                    Console.WriteLine($"Product: {kvp2.Key}, Price: {kvp2.Value}");
                }
            }
        }
    }
}
