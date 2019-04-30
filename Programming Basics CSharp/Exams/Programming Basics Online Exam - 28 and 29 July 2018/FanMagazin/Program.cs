using System;

namespace FanMagazin
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            double price = 0;
            double sum = 0;
            int counter = 0;

            double leftMoney = 0;
            double needMoney = 0;

            for (int i = 1; i <= n; i++)
            {
                string subject = Console.ReadLine();

                if(subject == "hoodie")
                {
                    price = 30;
                }
                else if (subject == "keychain")
                {
                    price = 4;
                }
                else if (subject == "T-shirt")
                {
                    price = 20;
                }
                else if (subject == "flag")
                {
                    price = 15;
                }
                else if (subject == "sticker")
                {
                    price = 1;
                }

                sum += price;

                counter++;
            }
            

            if (budget >= sum)
            {
                leftMoney = budget - sum;
                Console.WriteLine($"You bought {counter} items and left with {leftMoney:F0} lv.");
            }
            else
            {
                needMoney = sum - budget;
                Console.WriteLine($"Not enough money, you need {needMoney:F0} more lv.");
            }

            
            

        }
    }
}
