using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var cars = new List<Car>();

            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var inputIfno = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var model = inputIfno[0];
                var engineSpeed = int.Parse(inputIfno[1]);
                var enginePower = int.Parse(inputIfno[2]);

                var cargoWeight = int.Parse(inputIfno[3]);
                var cargoType = inputIfno[4];

                var tires = new Tire[4];
                var counter = 0;

                for (int tireIndex = 5; tireIndex < inputIfno.Length; tireIndex+=2)
                {
                    var currentTirePressure = double.Parse(inputIfno[tireIndex]);
                    var currentTireAge = int.Parse(inputIfno[tireIndex+1]);

                    var tire = new Tire(currentTirePressure, currentTireAge);
                    tires[counter++] = tire;
                }

                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            var cargoTypeCommand = Console.ReadLine();

            if (cargoTypeCommand == "flamable")
            {
                cars.Where(x => x.Engine.EnginePower > 250 && x.Cargo.CargoType == "flamable")
                    .ToList().ForEach(x => Console.WriteLine(x.Model));
            }
            else if(cargoTypeCommand == "fragile")
            {
                cars.Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(p => p.TirePressure < 1))
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }
        }
    }
}
