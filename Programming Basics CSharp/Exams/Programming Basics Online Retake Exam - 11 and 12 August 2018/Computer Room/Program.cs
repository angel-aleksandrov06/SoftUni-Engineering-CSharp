using System;

namespace Computer_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int hours = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            double pricePerHour = 0;

            if (day == "day")
            {
                switch (month)
                {
                    case "march":
                    case "april":
                    case "may":
                        {
                            pricePerHour = 10.50;
                        }
                        break;
                    case "june":
                    case "july":
                    case "august":
                        {
                            pricePerHour = 12.60;
                        }
                        break;
                    default:
                        break;
                }
            }
            else if(day == "night")
            {
                switch (month)
                {
                    case "march":
                    case "april":
                    case "may":
                        {
                            pricePerHour = 8.40;
                        }
                        break;
                    case "june":
                    case "july":
                    case "august":
                        {
                            pricePerHour = 10.20;
                        }
                        break;
                    default:
                        break;
                }
            }

            if (people >= 4)
            {
                pricePerHour = pricePerHour - (pricePerHour * 0.10);
            }
            if (hours >= 5)
            {
                pricePerHour = pricePerHour - (pricePerHour * 0.50);
            }

            double priceForAllPeople = pricePerHour * people*hours;
            double pricePerPerson = pricePerHour;

            Console.WriteLine($"Price per person for one hour: {pricePerPerson:F2}");
            Console.WriteLine($"Total cost of the visit: {priceForAllPeople:F2}");
        }
    }
}
