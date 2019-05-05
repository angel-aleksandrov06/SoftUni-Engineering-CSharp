using System;

namespace Puppy_Care
{
    class Program
    {
        static void Main(string[] args)
        {
            int byedFoodKG = int.Parse(Console.ReadLine());
            string comnad = Console.ReadLine();

            int byedFoogInGR = byedFoodKG * 1000;
            int Izqdenahrana = 0;


            while (comnad!="Adopted")
            {
                int eatFoodGR = int.Parse(comnad);

                Izqdenahrana += eatFoodGR;
                
                comnad = Console.ReadLine();
            }

            if (Izqdenahrana <= byedFoogInGR)
            {
                int leftFood = byedFoogInGR - Izqdenahrana;
                Console.WriteLine($"Food is enough! Leftovers: {leftFood} grams.");
            }
            else
            {
                int needFood = Izqdenahrana - byedFoogInGR;
                Console.WriteLine($"Food is not enough. You need {needFood} grams more.");
            }
        }
    }
}
