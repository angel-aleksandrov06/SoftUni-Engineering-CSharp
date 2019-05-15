using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double priceStudioOfDay = 0;
            double priceApartmentOfDay = 0;

            if (month=="May" || month=="October" )
            {
                priceStudioOfDay = 50;
                priceApartmentOfDay = 65;

                if (nights>7 && nights<14)
                {
                    priceStudioOfDay = priceStudioOfDay - 0.05 * priceStudioOfDay;
                }
                else if (nights > 14)
                {
                    priceStudioOfDay = priceStudioOfDay - 0.30 * priceStudioOfDay;
                    priceApartmentOfDay = priceApartmentOfDay - 0.10 * priceApartmentOfDay;
                }
            }
            else if (month =="June" || month=="September")
            {
                priceApartmentOfDay = 68.70;
                priceStudioOfDay = 75.20;

                if(nights>14)
                {
                    priceStudioOfDay = priceStudioOfDay - 0.20 * priceStudioOfDay;
                    priceApartmentOfDay = priceApartmentOfDay - 0.10 * priceApartmentOfDay;
                }
            }
            else if (month == "July" || month== "August")
            {
                priceStudioOfDay = 76;
                priceApartmentOfDay = 77;
                if (nights>14)
                {
                    priceApartmentOfDay = priceApartmentOfDay - 0.10 * priceApartmentOfDay;
                }
                 
            }
            double totalPriceStudio = priceStudioOfDay * nights;
            double totalPriceApartment = priceApartmentOfDay * nights;


            Console.WriteLine($"Apartment: {totalPriceApartment:F2} lv.");
            Console.WriteLine($"Studio: {totalPriceStudio:F2} lv.");




        }
    }
}
