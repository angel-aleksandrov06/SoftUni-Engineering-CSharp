using System;

namespace HappyCat_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hoursOfDays = int.Parse(Console.ReadLine());
            double parkTax = 0;
            double oneDayTax = 0;
            double totalTax = 0;

            for (int i = 1; i <= days; i++)
            {
                oneDayTax = 0;
                for (int j = 1; j <= hoursOfDays; j++)
                {
                    
                    parkTax = 0;
                    if(i%2==0 && j % 2 != 0)
                    {
                        parkTax = 2.5;
                    }
                    else if(i % 2 != 0 && j % 2 == 0)
                    {
                        parkTax = 1.25;
                    }
                    else
                    {
                        parkTax = 1;
                    }
                    oneDayTax += parkTax;
                }

                Console.WriteLine($"Day: {i} - {oneDayTax:F2} leva");
                totalTax += oneDayTax;
            }
            Console.WriteLine($"Total: {totalTax:F2} leva");
        }
    }
}
