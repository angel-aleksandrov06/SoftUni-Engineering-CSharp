using System;

namespace _3._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;
            double midPrice = 0;
            double totalPrice = 0;

            if (typeOfGroup == "Students")
            {
                if (day == "Friday")
                {
                    price = 8.45;
                }
                else if(day == "Saturday")
                {
                    price = 9.80;
                }
                else if (day == "Sunday")
                {
                    price = 10.46;
                }
            }
            else if(typeOfGroup== "Business")
            {
                if (day == "Friday")
                {
                    price = 10.90;
                }
                else if (day == "Saturday")
                {
                    price = 15.60;
                }
                else if (day == "Sunday")
                {
                    price = 16;
                }
            }
            else if(typeOfGroup == "Regular")
            {
                if (day == "Friday")
                {
                    price = 15;
                }
                else if (day == "Saturday")
                {
                    price = 20;
                }
                else if (day == "Sunday")
                {
                    price = 22.50;
                }
            }

            midPrice = price * people;
            totalPrice = midPrice;

            if (typeOfGroup == "Students" && people >= 30)
            {
                totalPrice = midPrice - (midPrice * 0.15);
            }
            else if (typeOfGroup == "Business" && people >= 100)
            {
                totalPrice = midPrice - (price * 10);
            }
            else if (typeOfGroup == "Regular" && people>=10 && people <= 20)
            {
                totalPrice = midPrice - (midPrice * 0.05);
            }
            Console.WriteLine($"Total price: {totalPrice:F2}");

        }
    }
}
