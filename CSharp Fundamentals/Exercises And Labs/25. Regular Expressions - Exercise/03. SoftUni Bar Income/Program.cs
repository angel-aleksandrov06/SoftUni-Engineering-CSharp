using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^%(?<customerName>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";

            List<string> customerName = new List<string>();
            List<string> products = new List<string>();
            List<double> totalPrice = new List<double>();

            string input = Console.ReadLine();

            while (input != "end of shift")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    customerName.Add(match.Groups["customerName"].Value);
                    products.Add(match.Groups["product"].Value);
                    int count = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);

                    totalPrice.Add(count * price);
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < customerName.Count; i++)
            {
                Console.WriteLine($"{customerName[i]}: {products[i]} - {totalPrice[i]:F2}");
            }

            var income = totalPrice.Sum();

            Console.WriteLine($"Total income: { income:F2}");
        }
    }
}
