using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double incom = double.Parse(Console.ReadLine());
            double averageSuccess = double.Parse(Console.ReadLine());
            double minWage = double.Parse(Console.ReadLine());
            double socialWage = Math.Round(minWage * 0.35);
            double exellentWage = Math.Floor(averageSuccess * 25);

            if (incom > minWage && averageSuccess < 4.50)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (incom < minWage && averageSuccess >= 5.50 && socialWage >= exellentWage)
            {
                Console.WriteLine($"You get a Social scholarship {socialWage} BGN");
            }
            else if (incom < minWage && averageSuccess >= 5.50 && socialWage < exellentWage)
            {
                Console.WriteLine($"You get a scholarship for excellent results {exellentWage} BGN");
            }
            else if (incom < minWage && averageSuccess > 4.50)
            {
                Console.WriteLine($"You get a Social scholarship {socialWage} BGN");
            }
            else if (incom >= minWage && averageSuccess >= 5.50)
            {
                Console.WriteLine($"You get a scholarship for excellent results {exellentWage} BGN");
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}