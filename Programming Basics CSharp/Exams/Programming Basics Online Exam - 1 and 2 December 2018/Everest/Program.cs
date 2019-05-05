using System;

namespace Everest
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            int clampMeters = int.Parse(Console.ReadLine());

            int walking = 5364;
            int finish = 8848;
            int counterDays = 1;


            while (comand != "END")
            {

                if (comand == "Yes")
                {
                    counterDays++;
                }
                
                if (counterDays >=6)
                {
                    break;
                }
                walking += clampMeters;
                if (walking >= finish)
                {
                    break;
                }
                
                comand = Console.ReadLine();
                if (comand != "END")
                {
                    clampMeters = int.Parse(Console.ReadLine());
                }

            }

            if (walking >= finish)
            {
                Console.WriteLine($"Goal reached for {counterDays} days!");
            }
            else
            {
                Console.WriteLine("Failed!");
                Console.WriteLine($"{walking}");
            }
        }
    }
}
