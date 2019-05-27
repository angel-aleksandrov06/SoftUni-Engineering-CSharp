using System;

namespace Wedding_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int countGests = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            int kuver = 20;
            int priceCouver = countGests * kuver;

            if (priceCouver <= budget)
            {
                int leftMoney = budget - priceCouver;
                double fireworks = 0.40 * leftMoney;
                double moneyDonation = leftMoney-fireworks;
                Console.WriteLine($"Yes! {fireworks:F0} lv are for fireworks and {moneyDonation:F0} lv are for donation.");
            }
            else
            {
                int needMoney = priceCouver - budget;
                Console.WriteLine($"They won't have enough money to pay the covert. They will need {needMoney:F0} lv more.");
            }
        }
    }
}
