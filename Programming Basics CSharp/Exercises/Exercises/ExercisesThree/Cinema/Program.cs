using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projecstion = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            int seats = rows * columns;

            double priceOfTicket = 0;

            if (projecstion == "Premiere")
            {
                priceOfTicket = 12;
            }
            else if (projecstion == "Normal")
            {
                priceOfTicket = 7.50;
            }else if (projecstion == "Discount")
            {
                priceOfTicket = 5.00;
            }

            double totalPrice = priceOfTicket * seats;

            Console.WriteLine($"{totalPrice:F2} leva");

        }
    }
}
