using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine().Split("@").Select(x => int.Parse(x)).ToList();

            string command = Console.ReadLine();
            int position = 0;
            int counter = 0;

            while (command!= "Merry Xmas!")
            {
                string[] commandArgs = command.Split(" ");

                int jumpLength = int.Parse(commandArgs[1]);

                position += jumpLength;
                if (position > houses.Count-1)
                {
                    while (position > houses.Count-1)
                    {
                        position -= houses.Count;
                    }
                }

                int peopleWithoutPresent = houses[position];

                if (peopleWithoutPresent <= 0)
                {
                    Console.WriteLine($"House {position} will have a Merry Christmas.");
                }
                else
                {
                    peopleWithoutPresent -= 2;
                    if (peopleWithoutPresent <= 0)
                    {
                        peopleWithoutPresent = 0;
                    }
                    counter++;
                }

                houses.RemoveAt(position);
                houses.Insert(position, peopleWithoutPresent);

                command = Console.ReadLine();
            }

            Console.WriteLine($"Santa's last position was {position}.");
            if(houses.Sum() == 0)
            {
                Console.WriteLine($"Mission was successful.");
            }
            else
            {
                int housesCount = 0;
                for (int i = 0; i < houses.Count; i++)
                {
                    housesCount++;
                    if (houses[i].Equals(0))
                    {
                        housesCount--;
                    }
                }
                Console.WriteLine($"Santa has failed {housesCount} houses.");
            }
        }
    }
}
