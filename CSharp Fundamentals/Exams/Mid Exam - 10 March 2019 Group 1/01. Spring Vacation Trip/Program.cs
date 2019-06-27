using System;

namespace _01._Spring_Vacation_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            decimal budgetGroup = decimal.Parse(Console.ReadLine());
            int group = int.Parse(Console.ReadLine());
            decimal priceOfFuelOfKm = decimal.Parse(Console.ReadLine());
            decimal priceOfFoodPerPersonPerDay = decimal.Parse(Console.ReadLine());
            decimal priceForRoomPerPersonPerNight = decimal.Parse(Console.ReadLine());



            decimal priceForFoodForAllTrip = priceOfFoodPerPersonPerDay * group * days;
            decimal priceForHotelForAllNights = priceForRoomPerPersonPerNight * group * days;

            if (group > 10)
            {
                priceForHotelForAllNights = priceForHotelForAllNights - (priceForHotelForAllNights * 0.25M);
            }

            decimal priceForFuelPerCurrentDay = 0;
            decimal currentExpenses = priceForFoodForAllTrip + priceForHotelForAllNights;
            bool isMoneyEnough = true;

            decimal priceForFoodPerDay = 0;
            decimal priceForHotelPerNight = 0;

            for (int i = 1; i <= days; i++)
            {
                
                decimal travelDistancePerDay = decimal.Parse(Console.ReadLine());

                priceForFuelPerCurrentDay = travelDistancePerDay * priceOfFuelOfKm;
                priceForFoodPerDay = priceOfFoodPerPersonPerDay * group;
                priceForHotelPerNight = priceForRoomPerPersonPerNight * group;

                currentExpenses += priceForFuelPerCurrentDay;

                if (i % 3 ==0 || i % 5 == 0)
                {
                    currentExpenses += 0.4M * currentExpenses;
                }

                if(i % 7 == 0)
                {
                    currentExpenses -= currentExpenses / group;
                }

                if(budgetGroup< currentExpenses)
                {
                    isMoneyEnough = false;
                    break;
                }
            }

            if (isMoneyEnough)
            {
                decimal leftMoney = budgetGroup - currentExpenses;
                Console.WriteLine($"You have reached the destination. You have {leftMoney:F2}$ budget left.");
            }
            else
            {
                decimal needMoney = currentExpenses - budgetGroup;
                Console.WriteLine($"Not enough money to continue the trip. You need {needMoney:F2}$ more.");
            }
        }
    }
}
