using System;

namespace Pastry_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int order = int.Parse(Console.ReadLine());
            int dayOfDecember = int.Parse(Console.ReadLine());
            double priceofCake = 0;
            double priceOfSouffle = 0;
            double priceOfBaklava = 0;
            double sum = 0;

            if (dayOfDecember <= 15 )
            {
                if (name == "Cake")
                {
                    priceofCake = 24;
                    sum = priceofCake * (1.0 * order);
                } else if (name == "Souffle")
                {
                    priceOfSouffle = 6.66;
                    sum = priceOfSouffle * (1.0 * order);
                }
                else if (name =="Baklava")
                {
                    priceOfBaklava = 12.60;
                    sum = priceOfBaklava* (1.0 * order);
                }
                 

            }
            else
            {
                if (name == "Cake")
                {
                    priceofCake = 28.70;
                    sum = priceofCake * (1.0 * order);
                }
                else if (name == "Souffle")
                {
                    priceOfSouffle = 9.80;
                    sum = priceOfSouffle * (1.0 * order);
                }
                else if (name == "Baklava")
                {
                    priceOfBaklava = 16.98;
                    sum = priceOfBaklava * (1.0 * order);
                }
                
                
                
            }

            if (dayOfDecember <= 22)
            {
                if (sum>100 && sum<200)
                {
                    sum = sum - (0.15 * sum);
                }
                else if(sum>=200)
                {
                    sum = sum - (0.25 * sum);
                }
            }
            if(dayOfDecember<=15)
            {
                sum = sum - (0.10 * sum);
            }
            Console.WriteLine($"{sum:F2}");
        }
    }
}
