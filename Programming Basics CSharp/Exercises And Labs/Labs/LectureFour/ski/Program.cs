using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ski
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string opinion = Console.ReadLine();
            
            int nights = days - 1;
            double price = 0;


            if (room == "room for one person")
            {
                price = nights * 18;
            }
            else if(room == "apartment")
            {
                price = nights * 25;

                if(nights <10)
                {
                    price = price - 0.3 * price;
                }
                else if (nights >= 10 && nights<=15)
                {
                    price = 0.65 * price;
                }
                else if (nights >15)
                {
                    price = 0.5 * price;
                }
            }
            else if (room == "president apartment")
            {
                price = nights * 35;

                if (nights < 10)
                {
                    price = price - 0.1 * price;
                }
                else if (nights >= 10 && nights <= 15)
                {
                    price = 0.85 * price;
                }
                else if (nights > 15)
                {
                    price = 0.8 * price;
                }
            }

            if (opinion == "positive")
            {
                price = 1.25 * price;
            }
            else if (opinion == "negative")
            {
                price = 0.9 * price;
            }

            Console.WriteLine($"{price:F2}");


        }
    }
}
