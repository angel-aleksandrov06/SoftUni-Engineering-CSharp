using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            var numberOfReadLines = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < numberOfReadLines; i++)
            {
                var inputCurrentCar = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = inputCurrentCar[0];
                var fuelAmount = double.Parse(inputCurrentCar[1]);
                var fuelConsumptionPerKilometer = double.Parse(inputCurrentCar[2]);
                
                cars.Add(new Car(model, fuelAmount, fuelConsumptionPerKilometer));
            }

            while (true)
            {
                var commands = Console.ReadLine();
                if (commands == "End")
                {
                    break;
                }

                var commandParts = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = commandParts[0];
                var carModel = commandParts[1];
                var distance = int.Parse(commandParts[2]);

                Car car = cars.FirstOrDefault(c => c.Model == carModel);

                if (!car.MoveTheCar(distance))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }
            cars.ForEach(Console.WriteLine);
        }
    }
}
