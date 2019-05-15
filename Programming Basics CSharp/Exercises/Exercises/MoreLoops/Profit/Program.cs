using System;

namespace Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int oneLV = int.Parse(Console.ReadLine());
            int twoLV = int.Parse(Console.ReadLine());
            int fiveLV = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());
            int momnetSum = 0;

            for (int i = 0; i <= oneLV; i++)
            {
                for (int j = 0; j <= twoLV; j++)
                {
                    for (int k = 0; k <= fiveLV; k++)
                    {
                        momnetSum = 0;
                        momnetSum = (1 * i) + (2 * j) + (5 * k);
                        if(momnetSum == sum)
                        {
                            Console.WriteLine($"{i} * 1 lv. + {j} * 2 lv. + {k} * 5 lv. = {momnetSum} lv.");
                        }
                    }
                }
            }
        }
    }
}
