using System;

namespace Christmas_Sweets
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceBaklavaKG = double.Parse(Console.ReadLine());
            double priceMufinsKG = double.Parse(Console.ReadLine());

            double kgShtolen = double.Parse(Console.ReadLine());
            double kgBonbons = double.Parse(Console.ReadLine());
            int kgCookies = int.Parse(Console.ReadLine());

            double priceShtolenKg = 0.6 * priceBaklavaKG + priceBaklavaKG;
            double priceBonbonsKg = 0.8 * priceMufinsKG + priceMufinsKG;
            double priceCookiesKg = 7.50;


            double sumShtolen = kgShtolen * priceShtolenKg;
            double sumBonbons = kgBonbons * priceBonbonsKg;
            double sumCookies = priceCookiesKg * (1.0 * kgCookies);

            double totalSum = sumBonbons + sumCookies + sumShtolen;
            Console.WriteLine($"{totalSum:F2}");

        }
    }
}
