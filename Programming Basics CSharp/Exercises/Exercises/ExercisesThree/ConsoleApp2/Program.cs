using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetGroup = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double fishersCount = double.Parse(Console.ReadLine());
            double currentPrice = 0;
            double finalCurrentPrice = 0;

            if (season == "Spring")
            {
                if (fishersCount <= 6)
                {
                    currentPrice = 3000 - 0.9 * 3000;
                }
                else if (fishersCount > 6 && fishersCount <= 11)
                {
                    currentPrice = 3000 - 0.85 * 3000;
                }
                else if (fishersCount >= 12)
                {
                    currentPrice = 3000 - 0.75 * 3000;
                }
            }
            else if (season == "Summer")
            {
                if (fishersCount <= 6)
                {
                    currentPrice = 4200 - 0.9 * 4200;
                }
                else if (fishersCount > 6 && fishersCount <= 11)
                {
                    currentPrice = 4200 - 0.85 * 4200;
                }
                else if (fishersCount >= 12)
                {
                    currentPrice = 4200 - 0.75 * 4200;
                }
            }
            else if (season == "Autumn")
            {
                if (fishersCount <= 6)
                {
                    currentPrice = 4200 - 0.9 * 4200;
                }
                else if (fishersCount > 6 && fishersCount <= 11)
                {
                    currentPrice = 4200 - 0.85 * 4200;
                }
                else if (fishersCount >= 12)
                {
                    currentPrice = 4200 - 0.75 * 4200;
                }
            }
            else if (season == "Winter")
            {
                if (fishersCount <= 6)
                {
                    currentPrice = 2600 - 0.9 * 2600;
                }
                else if (fishersCount > 6 && fishersCount <= 11)
                {
                    currentPrice = 2600 - 0.85 * 2600;
                }
                else if (fishersCount >= 12)
                {
                    currentPrice = 2600 - 0.75 * 2600;
                }
            }

            if (fishersCount % 2 == 0 && season != "Autumn")
            {
                finalCurrentPrice = currentPrice - (0.05 * currentPrice);
            }
            else
            {
                finalCurrentPrice = currentPrice;
            }

            if (budgetGroup >= finalCurrentPrice)
            {
                double leftMoney = budgetGroup - finalCurrentPrice;
                Console.WriteLine($"Yes! You have {leftMoney} leva left.");
            }
            else
            {
                double needMoney = finalCurrentPrice - budgetGroup;
                Console.WriteLine($"Not enough money! You need {needMoney} leva.");
            }
        }
    }
}
