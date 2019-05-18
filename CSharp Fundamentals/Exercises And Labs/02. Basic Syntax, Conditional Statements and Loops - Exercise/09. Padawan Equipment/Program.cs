using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightsabersOne = double.Parse(Console.ReadLine());
            double priceOfRobesOne = double.Parse(Console.ReadLine());
            double priceOfBeltsOne = double.Parse(Console.ReadLine());

            double freeBelts = Math.Floor(countOfStudents / 6.0);


            double priceOfLightsabers = priceOfLightsabersOne * (countOfStudents + Math.Ceiling(countOfStudents * 0.10));
            double priceOfRobes = priceOfRobesOne * countOfStudents;
            double priceOfBelts = priceOfBeltsOne * (countOfStudents - freeBelts);

            double sum = priceOfLightsabers + priceOfRobes + priceOfBelts;

            if (amountOfMoney >= sum)
            {
                Console.WriteLine($"The money is enough - it would cost {sum:F2}lv.");
            }
            else
            {
                double neededMoney = sum - amountOfMoney;
                Console.WriteLine($"Ivan Cho will need {neededMoney:F2}lv more.");
            }

        }
    }
}
