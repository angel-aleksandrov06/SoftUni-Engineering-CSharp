using System;
using System.Collections.Generic;

namespace _02._Hello__France
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputCommand = Console.ReadLine().Split("|");
            double budget = double.Parse(Console.ReadLine());

            double newBudget = budget;

            List<double> Cells = new List<double>();

            double profit = 0;

            for (int i = 0; i < inputCommand.Length; i++)
            {
                string[] command = inputCommand[i].Split("->");

                string type = command[0];
                double price = double.Parse(command[1]);


                if(type == "Clothes" && price <= 50.00)
                {
                    if (budget >= price)
                    {
                        budget -= price;
                        double newPrice = Math.Abs(price + (price * 0.40));
                        profit += newPrice - price;
                        Cells.Add(newPrice);
                    }
                }
                else if (type == "Shoes" && price <= 35.00)
                {
                    if (budget >= price)
                    {
                        budget -= price;
                        double newPrice = Math.Abs(price + (price * 0.40));
                        profit += newPrice - price;
                        Cells.Add(newPrice);
                    }
                }
                else if (type == "Accessories" && price <= 20.50)
                {
                    if (budget >= price)
                    {
                        budget -= price;
                        double newPrice = Math.Abs(price + (price * 0.40));
                        profit += newPrice - price;
                        Cells.Add(newPrice);
                    }
                }
            }

            for (int i = 0; i < Cells.Count; i++)
            {
                Console.Write($"{Cells[i]:F2} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Profit: {profit:F2}");

            newBudget += profit; 
            if(newBudget>= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}
