using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double excursionprice = double.Parse(Console.ReadLine());
            int puzzle = int.Parse(Console.ReadLine());
            int talkingkDoll = int.Parse(Console.ReadLine());
            int teddyBear = int.Parse(Console.ReadLine());
            int minion = int.Parse(Console.ReadLine());
            int truck = int.Parse(Console.ReadLine());

            double sum = (puzzle * 2.6) + (talkingkDoll * 3) + (teddyBear * 4.1) + (minion * 8.2) + (truck * 2);

            int sumToy = puzzle + talkingkDoll + teddyBear + minion + truck;
            double discount = 0.0;
            if (sumToy >= 50)
                {
                     discount = sum * 0.25;
                }
            double totalPrice = sum - discount;
            totalPrice = totalPrice - (totalPrice * 0.10);
            if (excursionprice <= totalPrice)
            {
                Console.WriteLine("Yes! {0:f2} lv left.", totalPrice - excursionprice);
            }
            else
            {
                Console.WriteLine("Not enough money! {0:f2} lv needed.", Math.Abs(totalPrice-excursionprice));

            }

        }
    }
}
