using System;

namespace Shopping_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeBreak = int.Parse(Console.ReadLine());
            double priceOnePart = double.Parse(Console.ReadLine());
            double priceOneProgram = double.Parse(Console.ReadLine());
            double priceWihtFrappe = double.Parse(Console.ReadLine());

            double timeAfterCoffe = timeBreak - 5;
            double timeForRelax = timeAfterCoffe - 6 - 4;

            double totalSum = 3 * priceOnePart + 2 * priceOneProgram + priceWihtFrappe;

            Console.WriteLine($"{totalSum:F2}");
            Console.WriteLine(timeForRelax);

        }
    }
}
