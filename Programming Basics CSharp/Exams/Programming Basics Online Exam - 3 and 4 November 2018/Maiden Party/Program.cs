using System;

namespace Maiden_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceParty = double.Parse(Console.ReadLine());
            int countPoslania = int.Parse(Console.ReadLine());
            int countRoses = int.Parse(Console.ReadLine());
            int countKeyToys = int.Parse(Console.ReadLine());
            int countKarikature = int.Parse(Console.ReadLine());
            int countluckys = int.Parse(Console.ReadLine());

            double pricePoslanie = 0.60;
            double priceRoses = 7.20;
            double priceKeyToys = 3.60;
            double priceKarikature = 18.20;
            double priceLuckeys = 22;

            int countOrders = countKarikature + countKeyToys + countluckys + countPoslania + countRoses;

            double owenSum = (pricePoslanie * countPoslania) + (priceRoses * countRoses) + (priceKeyToys * countKeyToys) + (priceKarikature * countKarikature) + (priceLuckeys * countluckys);
            

            if (countOrders >= 25)
            {
                owenSum = owenSum - (0.35 * owenSum);
            }
            double totalSum = owenSum - (0.10 * owenSum);

            if (totalSum >= priceParty)
            {
                double leftMoney = totalSum - priceParty;
                Console.WriteLine($"Yes! {leftMoney:F2} lv left.");
            }
            else
            {
                double needMoney = priceParty - totalSum;
                Console.WriteLine($"Not enough money! {needMoney:F2} lv needed.");
            }
        }
    }
}
