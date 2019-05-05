using System;

namespace Mountain_Run
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordSeconds = double.Parse(Console.ReadLine());
            double distanceMeters = double.Parse(Console.ReadLine());
            double timeSecondsForOneMeter = double.Parse(Console.ReadLine());

            double newDistance = distanceMeters * timeSecondsForOneMeter;
            double timeLate = Math.Floor(distanceMeters / 50) * 30;
            double totalTime = newDistance + timeLate;

            if (recordSeconds <= totalTime)
            {
                double deffTime = totalTime-recordSeconds;
                Console.WriteLine($"No! He was {deffTime:F2} seconds slower.");
            }
            else
            {
                Console.WriteLine($" Yes! The new record is {totalTime:F2} seconds.");
            }
        }
    }
}
