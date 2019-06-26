using System;

namespace Problem_1._Easter_Cozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            decimal priceOfOneKgFloor = decimal.Parse(Console.ReadLine());

            decimal priceOfOnePackEggs = 0.75M * priceOfOneKgFloor;
            decimal priceOfOneLMilk = priceOfOneKgFloor + (0.25M * priceOfOneKgFloor);
            decimal priceOf250mlMilk = priceOfOneLMilk / 4;

            int counterOfCozonacs = 0;

            decimal priceForOneCozonac = priceOfOneKgFloor + priceOfOnePackEggs + priceOf250mlMilk;

            int coloredEggs = 0;
            decimal moneyLeft = 0;

            while (budget >= 0)
            {
                decimal leftMoney = budget - priceForOneCozonac;
                if (leftMoney <= 0)
                {
                    moneyLeft = budget;
                    break;
                }
                else
                {
                    budget = leftMoney;
                    counterOfCozonacs++;
                    coloredEggs += 3;
                }
                if (counterOfCozonacs % 3 == 0 && counterOfCozonacs!=0)
                {
                    coloredEggs = coloredEggs - (counterOfCozonacs - 2);
                }

            }

            Console.WriteLine($"You made {counterOfCozonacs} cozonacs! Now you have {coloredEggs} eggs and {moneyLeft:F2}BGN left.");
        }
    }
}
