using System;

namespace Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());
            double lenghtUlei = double.Parse(Console.ReadLine());
            int secondsForHundertMeters = int.Parse(Console.ReadLine());

            int secondsKontrola = minutes * 60 + seconds;
            double namalqvashtoVreme = lenghtUlei / 120;
            double sumTime = namalqvashtoVreme * 2.5;
            double timeMartin = (lenghtUlei / 100) * secondsForHundertMeters - sumTime;

            if (timeMartin <= secondsKontrola)
            {
                Console.WriteLine($"Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {timeMartin:F3}.");
            }
            else
            {
                double needTime = timeMartin - secondsKontrola;
                Console.WriteLine($"No, Marin failed! He was {needTime:F3} second slower.");
            }
        }
    }
}
