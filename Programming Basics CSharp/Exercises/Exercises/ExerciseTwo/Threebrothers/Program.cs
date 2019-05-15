using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threebrothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double timeBrother1 = double.Parse(Console.ReadLine());
            double timeBrother2 = double.Parse(Console.ReadLine());
            double timeBrother3 = double.Parse(Console.ReadLine());
            double fishingTime = double.Parse(Console.ReadLine());

            double cleanigTime = 1 / (1 / timeBrother1 + 1 / timeBrother2 + 1 / timeBrother3);
            double rest = cleanigTime * 0.15;

            double totalCleaningTime = cleanigTime + rest;

            Console.WriteLine($"Cleaning time: {totalCleaningTime:F2}");

            if (fishingTime>=totalCleaningTime)
            {
                double left = Math.Floor(fishingTime - totalCleaningTime);
                Console.WriteLine($"Yes, there is a surprise - time left -> {left} hours." );
            }
            else
            {
                double need = Math.Ceiling(totalCleaningTime - fishingTime);
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {need} hours.");
            }


        }
    }
}
