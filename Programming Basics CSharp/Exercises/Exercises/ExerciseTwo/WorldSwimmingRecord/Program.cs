using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordSeconds = double.Parse(Console.ReadLine());
            double distanceMeters = double.Parse(Console.ReadLine());
            double seconsFormeters = double.Parse(Console.ReadLine());

            double swimTime = distanceMeters * seconsFormeters;
            double more15Meters = Math.Floor(distanceMeters / 15) * 12.5;
            double totalTime = (swimTime + more15Meters);

            if (recordSeconds <= totalTime)
            {
                double timeless = totalTime - recordSeconds;
                Console.WriteLine($"No, he failed! He was {timeless:F2} seconds slower.");

            }
            else if (recordSeconds > totalTime)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is { totalTime:F2} seconds.");
            }

        }
    }
}
