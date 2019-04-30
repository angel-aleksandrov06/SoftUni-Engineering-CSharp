using System;

namespace BeerAndChips
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int countBeer = int.Parse(Console.ReadLine());
            int countChips = int.Parse(Console.ReadLine());

          
            double needMoney = 0;
            double priceBeer = 1.20 * 1.0*countBeer;
            double priceOneChips = 0.45 * priceBeer;
            double priceChips = Math.Ceiling(priceOneChips *1.0* countChips);
            
            double sum = priceBeer + priceChips;

            if(budget>=sum) 
            {
                double leftMoney = budget - sum;
                Console.WriteLine($"{name} bought a snack and has {leftMoney:F2} leva left.");
            }
            else
            {
                needMoney = sum - budget;
                Console.WriteLine($"{name} needs {needMoney:F2} more leva!");
            }
        }
    }
}
