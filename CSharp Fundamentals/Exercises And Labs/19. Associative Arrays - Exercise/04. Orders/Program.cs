using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<double>>();

            var input = Console.ReadLine();

            while (input !="buy")
            {
                var splitedInput = input.Split(" ");

                var name = splitedInput[0];
                var price = double.Parse(splitedInput[1]);
                var quantity = int.Parse(splitedInput[2]);

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<double>());
                    dict[name].Add(price);
                    dict[name].Add(quantity);
                }
                else
                {
                    var oldQuantity = dict[name].ElementAt(1);
                    var newQuantity = oldQuantity + quantity;
                    dict[name].RemoveAt(1);
                    dict[name].Insert(1, newQuantity);

                    var oldPrice = dict[name].ElementAt(0);
                    if (oldPrice != price)
                    {
                        dict[name].RemoveAt(0);
                        dict[name].Insert(0, price);
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var item in dict)
            {
                var totalPrice = item.Value.ElementAt(0) * item.Value.ElementAt(1);

                Console.WriteLine($"{item.Key} -> {totalPrice:F2}");
            }
        }
    }
}
