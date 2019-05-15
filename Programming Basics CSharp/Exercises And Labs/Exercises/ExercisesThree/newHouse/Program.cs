using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeflowers = Console.ReadLine();
            int flowersCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double priceForOneFlower = 0;

            if(typeflowers == "Roses")
            {
                priceForOneFlower = 5;
            }
            else if(typeflowers == "Dahlias")
            {
                priceForOneFlower = 3.80;
            }
            else if (typeflowers == "Tulips")
            {
                priceForOneFlower = 2.80;
            }
            else if (typeflowers == "Narcissus")
            {
                priceForOneFlower = 3;
            }
            else if (typeflowers== "Gladiolus")
            {
                priceForOneFlower = 2.50;
            }

            double totalPrice = flowersCount * priceForOneFlower;

            if (flowersCount >80 && typeflowers == "Roses")
            {
                totalPrice = totalPrice - 0.10 * totalPrice;
            }
            else if (flowersCount >90 && typeflowers == "Dahlias")
            {
                totalPrice = totalPrice - 0.15 * totalPrice;
            }
            else if (flowersCount >80 && typeflowers == "Tulips")
            {
                totalPrice = totalPrice - 0.15 * totalPrice;
            }
            else if (flowersCount <120 && typeflowers =="Narcissus")
            {
                totalPrice = totalPrice + 0.15 * totalPrice;
            }
            else if (flowersCount <80 && typeflowers=="Gladiolus")
            {
                totalPrice = totalPrice + 0.20 * totalPrice;
            }



            if (budget >= totalPrice)
            {
                double leftMoney = budget - totalPrice;

                Console.WriteLine($"Hey, you have a great garden with {flowersCount} {typeflowers} and {leftMoney:F2} leva left.");
            }
            else
            {
                double needMoney = totalPrice - budget;
                Console.WriteLine($"Not enough money, you need {needMoney:F2} leva more.");
            }
        }
    }
}
