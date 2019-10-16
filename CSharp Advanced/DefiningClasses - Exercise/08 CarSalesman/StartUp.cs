using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();
            var engines = new List<Engine>();
            var countLinesInformationForEngine = int.Parse(Console.ReadLine());

            for (int i = 0; i < countLinesInformationForEngine; i++)
            {
                var inputParts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Engine engine = null;
                var model = inputParts[0];
                var power = int.Parse(inputParts[1]);
                engine = CheckAboutMorePartsForEngine(inputParts, model, power);

                engines.Add(engine);
            }

            var countLinesInformationForCar = int.Parse(Console.ReadLine());

            for (int i = 0; i < countLinesInformationForCar; i++)
            {
                var inputParts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Car car = null;
                var carModel = inputParts[0];
                var engineModel = inputParts[1];
                car = CheckAboutMorePartsForCar(engines, inputParts, carModel, engineModel);

                cars.Add(car);
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }

        private static Car CheckAboutMorePartsForCar(List<Engine> engines, string[] inputParts, string carModel, string engineModel)
        {
            Car car;
            Engine engine = engines.Where(x => x.Model == engineModel)
                         .FirstOrDefault();

            if (inputParts.Length == 2)
            {
                car = new Car(carModel, engine);
            }
            else if (inputParts.Length == 4)
            {
                var weght = int.Parse(inputParts[2]);
                var color = inputParts[3];

                car = new Car(carModel, engine, weght, color);
            }
            else
            {
                var isWeight = int.TryParse(inputParts[2], out int weight);

                if (isWeight)
                {
                    car = new Car(carModel, engine, weight);
                }
                else
                {
                    car = new Car(carModel, engine, inputParts[2]);
                }
            }

            return car;
        }

        private static Engine CheckAboutMorePartsForEngine(string[] inputParts, string model, int power)
        {
            Engine engine;
            if (inputParts.Length == 2)
            {
                engine = new Engine(model, power);
            }
            else if (inputParts.Length == 4)
            {
                var displacement = int.Parse(inputParts[2]);
                var efficiency = inputParts[3];

                engine = new Engine(model, power, displacement, efficiency);
            }
            else
            {
                var isDisplacement = int.TryParse(inputParts[2], out int displacement);

                if (isDisplacement)
                {
                    engine = new Engine(model, power, displacement);
                }
                else
                {
                    engine = new Engine(model, power, inputParts[2]);
                }
            }

            return engine;
        }
    }
}
