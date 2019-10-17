using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var command = Console.ReadLine();
            var listOfTires = new List<Tire[]>();
            var listOfEngines = new List<Engine>();
            var listOfCars = new List<Car>();

            while (command != "No more tires")
            {
                var splitedInputCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var tires = new Tire[4];
                var counter = 0;

                for (int i = 0; i < splitedInputCommand.Length; i+=2)
                {
                    var yearOfTires = int.Parse(splitedInputCommand[i]);
                    var pressureOfTire = double.Parse(splitedInputCommand[i+1]);
                    tires[counter] = new Tire(yearOfTires, pressureOfTire);
                    counter++;
                }

                listOfTires.Add(tires);
                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "Engines done")
            {
                var splitedInputCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var horsePower = int.Parse(splitedInputCommand[0]);
                var cubicCapacity = double.Parse(splitedInputCommand[1]);

                var engine = new Engine(horsePower, cubicCapacity);
                listOfEngines.Add(engine);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "Show special")
            {
                var splitedInputCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var make = splitedInputCommand[0];
                var model = splitedInputCommand[1];
                var yearOfCar = int.Parse(splitedInputCommand[2]);
                var fuelQuantity = double.Parse(splitedInputCommand[3]);
                var fuelConsumption = double.Parse(splitedInputCommand[4]);
                var engingeIndex = int.Parse(splitedInputCommand[5]);
                var tiresIndex = int.Parse(splitedInputCommand[6]);

                var engine = listOfEngines[engingeIndex];
                var tires = listOfTires[tiresIndex];

                var car = new Car(make, model, yearOfCar, fuelQuantity, fuelConsumption, engine, tires);
                listOfCars.Add(car);

                command = Console.ReadLine();
            }

            var listOfSpecialCars = listOfCars
                .Where(x => x.Drive(20) >= x.FuelQuantity)
                .Where(x => x.Year >= 2017)
                .Where(x => x.Engine.HorsePower >= 330)
                .Where((x, p) => x.Tires.Sum(y => y.Pressure) >= 9 && x.Tires.Sum(y => y.Pressure) <= 10).ToList();

            foreach (var specialCar in listOfSpecialCars)
            {
                Console.WriteLine($"Make: {specialCar.Make}");
                Console.WriteLine($"Model: {specialCar.Model}");
                Console.WriteLine($"Year: {specialCar.Year}");
                Console.WriteLine($"HorsePowers: {specialCar.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {specialCar.FuelQuantity}");
            }
        }
    }
}
