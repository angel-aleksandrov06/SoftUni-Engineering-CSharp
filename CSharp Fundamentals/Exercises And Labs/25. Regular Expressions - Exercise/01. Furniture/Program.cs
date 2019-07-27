using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<name>[A-Za-z]+)<<(?<price>[0-9]+\.?[0-9]*)!(?<quantity>\d+)";

            Regex regex = new Regex(pattern);

            List<string> furniture = new List<string>();
            Decimal totalPrice = 0; 
            

            string input = Console.ReadLine();

            while (input != "Purchase")
            {
                Match matchedFurniture = regex.Match(input);

                if (matchedFurniture.Success)
                {
                    furniture.Add(matchedFurniture.Groups["name"].Value);
                    Decimal price = Decimal.Parse(matchedFurniture.Groups["price"].Value);
                    int quantity = int.Parse(matchedFurniture.Groups["quantity"].Value);

                    totalPrice += price * quantity;
                }



                input = Console.ReadLine();
            }

            Console.WriteLine($"Bought furniture:");

            foreach (var furni in furniture)
            {
                Console.WriteLine(furni);
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
