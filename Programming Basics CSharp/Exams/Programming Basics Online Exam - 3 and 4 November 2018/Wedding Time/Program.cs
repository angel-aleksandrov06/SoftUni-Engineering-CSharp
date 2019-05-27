using System;

namespace Wedding_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceWhiskeyL = double.Parse(Console.ReadLine());
            double waterL = double.Parse(Console.ReadLine());
            double wineL = double.Parse(Console.ReadLine());
            double shampagneL = double.Parse(Console.ReadLine());
            double whiskeyL = double.Parse(Console.ReadLine());

            double priceShampagneL = priceWhiskeyL - (0.50 * priceWhiskeyL);
            double priceWineL = priceShampagneL - (0.60 * priceShampagneL);
            double priceWaterL = priceShampagneL - (0.90 * priceShampagneL);

            double sum = (priceWhiskeyL * whiskeyL) + (priceShampagneL * shampagneL) + (priceWineL * wineL) + (priceWaterL * waterL);

            Console.WriteLine($"{sum:F2}");
        }
    }
}
