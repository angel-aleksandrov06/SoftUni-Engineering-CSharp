using System;

namespace Souvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            string souvenirs = Console.ReadLine();
            int counterBySouvenirs = int.Parse(Console.ReadLine());
            double price = 0;
            double totalSum = 0;

            

            if (team == "Argentina")
            {
                if (souvenirs== "flags")
                {
                    price = 3.25;
                    totalSum = price * counterBySouvenirs;
                    Console.WriteLine($"Pepi bought {counterBySouvenirs} {souvenirs} of {team} for {totalSum:F2} lv.");
                }
                else if (souvenirs == "caps")
                {
                    price = 7.20;
                    totalSum = price * counterBySouvenirs;
                    Console.WriteLine($"Pepi bought {counterBySouvenirs} {souvenirs} of {team} for {totalSum:F2} lv.");
                }
                else if (souvenirs == "posters")
                {
                    price = 5.10;
                    totalSum = price * counterBySouvenirs;
                    Console.WriteLine($"Pepi bought {counterBySouvenirs} {souvenirs} of {team} for {totalSum:F2} lv.");
                }
                else if(souvenirs == "stickers")
                {
                    price = 1.25;
                    totalSum = price * counterBySouvenirs;
                    Console.WriteLine($"Pepi bought {counterBySouvenirs} {souvenirs} of {team} for {totalSum:F2} lv.");
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }

            }
            else if(team == "Brazil")
            {
                if (souvenirs == "flags")
                {
                    price = 4.20;
                    totalSum = price * counterBySouvenirs;
                    Console.WriteLine($"Pepi bought {counterBySouvenirs} {souvenirs} of {team} for {totalSum:F2} lv.");
                }
                else if (souvenirs == "caps")
                {
                    price = 8.50;
                    totalSum = price * counterBySouvenirs;
                    Console.WriteLine($"Pepi bought {counterBySouvenirs} {souvenirs} of {team} for {totalSum:F2} lv.");
                }
                else if (souvenirs == "posters")
                {
                    price = 5.35;
                    totalSum = price * counterBySouvenirs;
                    Console.WriteLine($"Pepi bought {counterBySouvenirs} {souvenirs} of {team} for {totalSum:F2} lv.");
                }
                else if (souvenirs == "stickers")
                {
                    price = 1.20;
                    totalSum = price * counterBySouvenirs;
                    Console.WriteLine($"Pepi bought {counterBySouvenirs} {souvenirs} of {team} for {totalSum:F2} lv.");
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }
            }
            else if (team == "Croatia")
            {
                if (souvenirs == "flags")
                {
                    price = 2.75;
                    totalSum = price * counterBySouvenirs;
                    Console.WriteLine($"Pepi bought {counterBySouvenirs} {souvenirs} of {team} for {totalSum:F2} lv.");
                }
                else if (souvenirs == "caps")
                {
                    price = 6.90;
                    totalSum = price * counterBySouvenirs;
                    Console.WriteLine($"Pepi bought {counterBySouvenirs} {souvenirs} of {team} for {totalSum:F2} lv.");
                }
                else if (souvenirs == "posters")
                {
                    price = 4.95;
                    totalSum = price * counterBySouvenirs;
                    Console.WriteLine($"Pepi bought {counterBySouvenirs} {souvenirs} of {team} for {totalSum:F2} lv.");
                }
                else if (souvenirs == "stickers")
                {
                    price = 1.10;
                    totalSum = price * counterBySouvenirs;
                    Console.WriteLine($"Pepi bought {counterBySouvenirs} {souvenirs} of {team} for {totalSum:F2} lv.");
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }
            }
            else if (team == "Denmark")
            {
                if (souvenirs == "flags")
                {
                    price = 3.10;
                    totalSum = price * counterBySouvenirs;
                    Console.WriteLine($"Pepi bought {counterBySouvenirs} {souvenirs} of {team} for {totalSum:F2} lv.");
                }
                else if (souvenirs == "caps")
                {
                    price = 6.50;
                    totalSum = price * counterBySouvenirs;
                    Console.WriteLine($"Pepi bought {counterBySouvenirs} {souvenirs} of {team} for {totalSum:F2} lv.");
                }
                else if (souvenirs == "posters")
                {
                    price = 4.80;
                    totalSum = price * counterBySouvenirs;
                    Console.WriteLine($"Pepi bought {counterBySouvenirs} {souvenirs} of {team} for {totalSum:F2} lv.");
                }
                else if (souvenirs == "stickers")
                {
                    price = 0.90;
                    totalSum = price * counterBySouvenirs;
                    Console.WriteLine($"Pepi bought {counterBySouvenirs} {souvenirs} of {team} for {totalSum:F2} lv.");
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }
            }
            else
            {
                Console.WriteLine("Invalid country!");
            }
        }
    }
}
