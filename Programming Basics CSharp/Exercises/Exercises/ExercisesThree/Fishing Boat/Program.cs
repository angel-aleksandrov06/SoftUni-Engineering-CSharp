using System;

namespace Fishing_Boat
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
                    currentPrice = 3000 - 0.10 * 3000;
                }
                else if (fishersCount>6 && fishersCount<=11)
                {
                    currentPrice = 3000 - 0.15 * 3000;
                }
                else if (fishersCount>=12)
                {
                    currentPrice = 3000 - 0.25 * 3000;
                }
            }
            else if (season == "Summer")
            {
                if (fishersCount <= 6)
                {
                    currentPrice = 4200 - 0.10*4200;
                }
                else if (fishersCount > 6 && fishersCount <= 11)
                {
                    currentPrice = 4200 - 0.15 * 4200;
                }
                else if (fishersCount >= 12)
                {
                    currentPrice = 4200 - 0.25 * 4200;
                }
            }
            else if (season == "Autumn")
            {
                if (fishersCount <= 6)
                {
                    currentPrice = 4200 - 0.10 * 4200;
                }
                else if (fishersCount > 6 && fishersCount <= 11)
                {
                    currentPrice = 4200 - 0.15 * 4200;
                }
                else if (fishersCount >= 12)
                {
                    currentPrice = 4200 - 0.25 * 4200;
                }
            }
            else if (season == "Winter")
            {
                if (fishersCount <= 6)
                {
                    currentPrice = 2600 - 0.10 * 2600;
                }
                else if (fishersCount > 6 && fishersCount <= 11)
                {
                    currentPrice = 2600 - 0.15 * 2600;
                }
                else if (fishersCount >= 12)
                {
                    currentPrice = 2600 - 0.25 * 2600;
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

            if (budgetGroup>=finalCurrentPrice)
            {
                double leftMoney = budgetGroup - finalCurrentPrice;
                Console.WriteLine($"Yes! You have {leftMoney:F2} leva left.");
            }
            else
            {
                double needMoney = finalCurrentPrice - budgetGroup;
                Console.WriteLine($"Not enough money! You need {needMoney:F2} leva.");
            }


        }
    }
}
