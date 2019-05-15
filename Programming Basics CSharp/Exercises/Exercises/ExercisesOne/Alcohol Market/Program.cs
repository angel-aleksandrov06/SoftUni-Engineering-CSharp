using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcohol_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double pricewhiskey = double.Parse(Console.ReadLine());
            double beerliters = double.Parse(Console.ReadLine());
            double wineLiters = double.Parse(Console.ReadLine());
            double rakiaLiters = double.Parse(Console.ReadLine());
            double whiskeyLiters = double.Parse(Console.ReadLine());

            double priceRakia = pricewhiskey / 2;
            double pricewine = priceRakia - 0.4 * priceRakia;
            double priceBeer = priceRakia - 0.8 * priceRakia;

            double totalSum = whiskeyLiters * pricewhiskey + beerliters * priceBeer + wineLiters * pricewine + rakiaLiters * priceRakia;

            Console.WriteLine($"{totalSum:F2}");







        }
    }
}
