using System;

namespace ExampleTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            int countSectors = int.Parse(Console.ReadLine());
            int stadionCapacity = int.Parse(Console.ReadLine());
            double priceOfOneTicket = double.Parse(Console.ReadLine());

            double insideMoney = stadionCapacity*1.0 * priceOfOneTicket;
            double insideMoneyFromOneSector = insideMoney / countSectors;

            double moneyForCharity = (insideMoney - (insideMoneyFromOneSector * 0.75)) / 8;

            Console.WriteLine($"Total income - {insideMoney:F2} BGN");
            Console.WriteLine($"Money for charity - {moneyForCharity:F2} BGN");


           


        }
    }
}
