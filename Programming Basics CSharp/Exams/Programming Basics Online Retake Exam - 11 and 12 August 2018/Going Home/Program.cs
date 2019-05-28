using System;

namespace Going_Home
{
    class Program
    {
        static void Main(string[] args)
        {
            int distance = int.Parse(Console.ReadLine());
            int petrol = int.Parse(Console.ReadLine());
            double pricePetrol = double.Parse(Console.ReadLine());
            int money = int.Parse(Console.ReadLine());

            double conCar = distance*1.0 * petrol / 100;
            double costMoney = conCar * pricePetrol;
            if (costMoney <= money)
            {
                double spendMoney = money - costMoney;
                Console.WriteLine($"You can go home. {spendMoney:F2} money left.");
            }
            else
            {
                double reciveMoney = money / 5;
                Console.WriteLine($"Sorry, you cannot go home. Each will receive {reciveMoney:F2} money.");
            }

        }
    }
}
