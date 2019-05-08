using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season= Console.ReadLine();
            string destionation = "";
            string placeToStay = "";
            double price = 0;

            

            if (budget<=100)
            {
                destionation = "Bulgaria";
                if (season == "summer")
                {
                    placeToStay = "Camp";
                    price = 0.30 * budget;
                }
                else if (season == "winter")
                {
                    placeToStay = "Hotel";
                    price = 0.70 * budget;
                }
                
            }
            else if (budget<=1000)
            {
                destionation = "Balkans";
                if (season =="summer")
                {
                    placeToStay = "Camp";
                    price = 0.40 * budget;
                }
                else if(season == "winter")
                {
                    placeToStay = "Hotel";
                    price = 0.80 * budget;
                }
            }
            else if (budget > 1000)
            {
                destionation = "Europe";
                placeToStay = "Hotel";
                price = 0.90 * budget;
            }

            Console.WriteLine($"Somewhere in {destionation}");
            Console.WriteLine($"{placeToStay} - {price:F2}");



        }
    }
}
