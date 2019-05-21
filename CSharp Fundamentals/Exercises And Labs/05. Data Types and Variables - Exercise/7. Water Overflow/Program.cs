using System;

namespace _7._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int waterTank = 255;
            int loops = int.Parse(Console.ReadLine());

            int sumWater = 0;
            for (int i = 0; i < loops; i++)
            {
                int quantitiesWater = int.Parse(Console.ReadLine());

                if (waterTank >= quantitiesWater)
                {
                    sumWater += quantitiesWater;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                waterTank = waterTank - quantitiesWater;
            }

            Console.WriteLine(sumWater);
        }
    }
}
