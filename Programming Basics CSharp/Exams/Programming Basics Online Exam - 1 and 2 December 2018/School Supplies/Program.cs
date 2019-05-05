using System;

namespace School_Supplies
{
    class Program
    {
        static void Main(string[] args)
        {
            int pacPens = int.Parse(Console.ReadLine());
            int pacMarkers = int.Parse(Console.ReadLine());
            double ltWoshDesk = double.Parse(Console.ReadLine());
            int percentRabbat = int.Parse(Console.ReadLine());

            double onePacPens = 5.80;
            double onePacMarkers = 7.20;
            double oneLiterWosh = 1.20;

            double pricePens = onePacPens * 1.0*pacPens;
            double priceMarkers = onePacMarkers * 1.0*pacMarkers;
            double priceWosh = ltWoshDesk * oneLiterWosh;

            double sum = priceMarkers + pricePens + priceWosh;
            double totalSum = sum - ((sum * percentRabbat)/100);

            Console.WriteLine($"{totalSum:F3}");
        }
    }
}
