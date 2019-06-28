using System;

namespace _01._Cooking_Masterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceFloorPackage = double.Parse(Console.ReadLine());
            double priceSingleEgg = double.Parse(Console.ReadLine());
            double priceApronOne = double.Parse(Console.ReadLine());


            int freeFloor = students / 5;

            double sum = priceApronOne * Math.Ceiling(students * 1.20) + (priceSingleEgg * 10 * students) + priceFloorPackage * (students - freeFloor);

            if (sum <= budget)
            {
                Console.WriteLine($"Items purchased for {sum:F2}$.");
            }
            else
            {
                double neededMoney = sum - budget;
                Console.WriteLine($"{neededMoney:F2}$ more needed.");
            }
        }
    }
}
