using System;

namespace Trekking_equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int alpensCount = int.Parse(Console.ReadLine());
            int carabirens = int.Parse(Console.ReadLine());
            int rops = int.Parse(Console.ReadLine());
            int picel = int.Parse(Console.ReadLine());

            int oneCarabiners = 36;
            double oneRop = 3.60; 
            double onepicel = 19.80;

            double priceCarabiners = 1.0 * carabirens * oneCarabiners;
            double priceRops = oneRop * rops;
            double pricePicels = onepicel * picel;

            double sumForOnePerson = priceCarabiners + pricePicels + priceRops;
            double sumForAllPeople = sumForOnePerson * alpensCount;
            double totalSum = sumForAllPeople + (20 * sumForAllPeople) / 100;

            Console.WriteLine($"{totalSum:F2}");
        }
    }
}
