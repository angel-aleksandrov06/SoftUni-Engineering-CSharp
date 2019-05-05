using System;

namespace Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int countDays = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string rating = Console.ReadLine();

            double price = 0;
            int countNights = countDays - 1;

            double roomForOnePerson = 18.00;
            double apartment = 25.00;
            double presidentApartment = 35.00;

            if (countDays < 10)
            {
                if (room == "room for one person")
                {
                    price = countNights * roomForOnePerson;
                }
                else if (room == "apartment")
                {
                    price = countNights * apartment;
                    price = price - (price * 0.30);
                }
                else if (room == "president apartment")
                {
                    price = countNights * presidentApartment;
                    price = price - (price * 0.10);
                }
            }
            else if (countDays >= 10 && countDays <= 15)
            {
                if (room == "room for one person")
                {
                    price = countNights * roomForOnePerson;
                }
                else if (room == "apartment")
                {
                    price = countNights * apartment;
                    price = price - (price * 0.35);
                }
                else if (room == "president apartment")
                {
                    price = countNights * presidentApartment;
                    price = price - (price * 0.15);
                }

            }
            else if (countDays > 15)
            {
                if (room == "room for one person")
                {
                    price = countNights * roomForOnePerson;
                }
                else if (room == "apartment")
                {
                    price = countNights * apartment;
                    price = price - (price * 0.50);
                }
                else if (room == "president apartment")
                {
                    price = countNights * presidentApartment;
                    price = price - (price * 0.20);
                }
            }

            if (rating == "positive")
            {
                price = price + (price * 0.25);
            }
            else if (rating == "negative")
            {
                price = price - (price * 0.10);
            }
            Console.WriteLine($"{price:F2}");
        }
    }
}
