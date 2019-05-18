using System;

namespace _4._Back_in_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int onlyMinutes = (hours * 60) + minutes + 30;

            int newHours = onlyMinutes / 60;
            int newMinutes = onlyMinutes % 60;

            if (newHours >= 24)
            {
                newHours -= 24;
            }

            Console.WriteLine($"{newHours}:{newMinutes:D2}");

        }
    }
}
