using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var parking = new HashSet<string>();

            while (input != "END")
            {
                var commandsParts = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                var direction = commandsParts[0];
                var carNumber = commandsParts[1];

                if (direction == "IN")
                {
                    parking.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    if (parking.Any() && parking.Contains(carNumber))
                    {
                        parking.Remove(carNumber);
                    }
                }

                input = Console.ReadLine();
            }

            if (parking.Any())
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
