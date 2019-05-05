using System;

namespace School_Trip
{
    class Program
    {
        static void Main(string[] args)
        {

            int countDaysWithoutAni = int.Parse(Console.ReadLine());
            int foodKG = int.Parse(Console.ReadLine());
            double firstDog = double.Parse(Console.ReadLine());
            double secondDog = double.Parse(Console.ReadLine());
            double thirdDog = double.Parse(Console.ReadLine());

            double foodFirstDog = countDaysWithoutAni * 1.0 * firstDog;
            double foodSecondDog = countDaysWithoutAni * 1.0 * secondDog;
            double foodThirdDog = countDaysWithoutAni * 1.0 * thirdDog;
            double allFood = foodFirstDog + foodSecondDog + foodThirdDog;

            if (allFood<=foodKG)
            {
                double foodLeft = Math.Floor(foodKG - allFood);
                Console.WriteLine($"{foodLeft} kilos of food left.");
            }
            else
            {
                double foodNeed = Math.Ceiling(allFood - foodKG);
                Console.WriteLine($"{foodNeed} more kilos of food are needed.");
            }


        }
    }
}
