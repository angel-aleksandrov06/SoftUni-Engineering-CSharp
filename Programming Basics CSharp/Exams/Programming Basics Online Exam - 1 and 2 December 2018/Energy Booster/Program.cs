using System;

namespace Energy_Booster
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string set = Console.ReadLine();
            int countSets = int.Parse(Console.ReadLine());
            double price = 0;
            double priceOneSEt = 0;

            if (set == "small")
            {
                switch(name)
                {
                    case "Watermelon":
                            price = 56;
                        break;
                    case "Mango":
                            price = 36.66;
                        break;
                    case "Pineapple":
                            price = 42.10;
                        break;
                    case "Raspberry":
                            price = 20;
                        break;
                }

                priceOneSEt = price * 2;

            }
            else if (set == "big")
            {
                switch (name)
                {
                    case "Watermelon":
                        price = 28.70;
                        break;
                    case "Mango":
                        price = 19.60;
                        break;
                    case "Pineapple":
                        price = 24.80;
                        break;
                    case "Raspberry":
                        price = 15.20;
                        break;
                }

                priceOneSEt = price * 5;

            }
            double priceForAllSets = priceOneSEt * countSets;

            if (priceForAllSets>=400 && priceForAllSets<=1000)
            {
                priceForAllSets = priceForAllSets - (priceForAllSets * 0.15);
            }
            else if (priceForAllSets > 1000)
            {
                priceForAllSets = priceForAllSets - (priceForAllSets * 0.50);
            }
            Console.WriteLine($"{priceForAllSets:F2} lv.");
        }
    }
}
