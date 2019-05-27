using System;

namespace Honeymoon
{
    class Program
    {
        static void Main(string[] args)
        {
            double budger = double.Parse(Console.ReadLine());
            string town = Console.ReadLine();
            int countNights = int.Parse(Console.ReadLine());
            int pricehotel = 0;
            int priceFly = 0;
            double sum = 0;

            switch (town)
            {
                case "Cairo":
                    pricehotel = 250*2* countNights;
                    priceFly = 600;
                    sum = pricehotel + priceFly;
                    break;
                case "Paris":
                    pricehotel = 150*2* countNights;
                    priceFly = 350;
                    sum = pricehotel + priceFly;
                    break;
                case "Lima":
                    pricehotel = 400*2*countNights;
                    priceFly = 850;
                    sum = pricehotel + priceFly;
                    break;
                case "New York":
                    pricehotel = 300*2* countNights;
                    priceFly = 650;
                    sum = pricehotel + priceFly;
                    break;
                case "Tokyo":
                    pricehotel = 350*2* countNights;
                    priceFly = 700;
                    sum = pricehotel + priceFly;
                    break;
                default:
                    break;
            }


            if (countNights<5)
            {
                if(town== "Cairo" || town== "New York")
                {
                    sum = sum*1.0 - (0.03 * sum);
                }
            }
            else if(countNights>=5 && countNights < 10)
            {
                if (town == "Cairo" || town == "New York")
                {
                    sum = sum * 1.0 - (0.05 * sum);
                }
                else if(town == "Paris")
                {
                    sum = sum * 1.0 - (0.07 * sum);
                }
            }
            else if (countNights >=10 && countNights<25)
            {
                if (town == "Cairo")
                {
                    sum = sum * 1.0 - (0.10 * sum);
                }
                else if (town == "Paris" || town== "New York" || town == "Tokyo")
                {
                    sum = sum * 1.0 - (0.12 * sum);
                }
            }
            else if (countNights >=25 && countNights <50)
            {
                if (town == "Cairo" || town == "Tokyo")
                {
                    sum = sum * 1.0 - (0.17 * sum);
                }
                else if (town == "Paris")
                {
                    sum = sum * 1.0 - (0.22 * sum);
                }
                else if (town=="Lima" || town == "New York")
                {
                    sum = sum * 1.0 - (0.19 * sum);
                }
            }
            else if (countNights >= 50)
            {
                sum = sum * 1.0 - (0.30 * sum);
            }

            if (sum < budger)
            {
                double leftMoney = budger - sum;
                Console.WriteLine($"Yes! You have {leftMoney:F2} leva left.");
            }
            else
            {
                double needMoney = sum - budger;
                Console.WriteLine($"Not enough money! You need {needMoney:F2} leva.");
            }
        }
    }
}
