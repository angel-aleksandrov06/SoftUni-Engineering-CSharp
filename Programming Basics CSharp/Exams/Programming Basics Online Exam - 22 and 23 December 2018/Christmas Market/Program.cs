using System;

namespace Christmas_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double MoneyToCatch = double.Parse(Console.ReadLine());
            int fentasi = int.Parse(Console.ReadLine());
            int horur = int.Parse(Console.ReadLine());
            int romantics = int.Parse(Console.ReadLine());

            double donatedSum = 0;
            double receive = 0;
            double needMoney = 0;

            double priceFentasi = 14.90;
            double priceHorur = 9.80;
            double priceRomantics = 4.30;

            double sumAfterSelss = priceFentasi * (1.0*fentasi) + priceHorur * (1.0*horur) + priceRomantics * (1.0*romantics);
            double DDS = 0.20*sumAfterSelss;
            double totalSum = sumAfterSelss - DDS;

            double moneyOverPoint = 0;
            double moneyForSellers = 0;

            if (totalSum>MoneyToCatch)
            {
                moneyOverPoint = totalSum - MoneyToCatch;
                moneyForSellers = 0.10 * moneyOverPoint;
                receive = Math.Floor(moneyForSellers);
                donatedSum = MoneyToCatch + (moneyOverPoint - receive);
                Console.WriteLine($" {donatedSum:F2} leva donated.");
                Console.WriteLine($"Sellers will receive {receive} leva.");
            }
            else
            {
                needMoney = MoneyToCatch - totalSum;
                Console.WriteLine($"{needMoney:F2} money needed.");
            }


        }
    }
}
