using System;

namespace _01._Party_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int partySizeCount = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int partySize = partySizeCount;

            int amountCoints = 0;


            for (int i = 1; i <= days; i++)
            {
                if (i == 10 || i == 20 || i == 30 || i == 40 || i == 50 || i == 60 || i == 70 || i == 80 || i == 90 || i == 100)
                {
                    partySize = partySize - 2;
                }
                if (i == 15 || i == 30 || i == 45 || i == 60 || i == 75 || i == 90)
                {
                    partySize = partySize + 5;
                }

                int eariningCoints = 50;
                int foodPerCompanion = 2 * partySize;
                int waterPerCompanion = 3 * partySize;
                int monsterCointsPerCompanion = 20 * partySize;

                amountCoints += (eariningCoints - foodPerCompanion);

                if (i % 3 == 0)
                {
                    amountCoints -= waterPerCompanion;
                }

                if (i % 5 == 0)
                {
                    amountCoints += monsterCointsPerCompanion;

                    if (i % 3 == 0)
                    {
                        amountCoints -= (2 * partySize);
                    }
                }
            }
            int CointsForEveryOne = amountCoints / partySize;

            Console.WriteLine($"{partySize} companions received {CointsForEveryOne} coins each.");
        }
    }
}
