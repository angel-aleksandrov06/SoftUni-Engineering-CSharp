namespace _01Vehicles.Core
{
    using System;
    using System.Linq;

    using Model;

    public class Engine
    {
        public void Run()
        {
            var carInfo = Console.ReadLine()
                .Split()
                .ToArray();

            var truckInfo = Console.ReadLine()
                .Split()
                .ToArray();

            var carFuelQuantity = double.Parse(carInfo[1]);
            var carFuelConsumption = double.Parse(carInfo[2]);

            var truckFuelQuantity = double.Parse(truckInfo[1]);
            var truckFuelConsumption = double.Parse(truckInfo[2]);

            var car = new Car(carFuelQuantity, carFuelConsumption);
            var truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            var conut = int.Parse(Console.ReadLine());

            for (int i = 0; i < conut; i++)
            {
                var inputCommnad = Console.ReadLine()
                    .Split()
                    .ToArray();

                var command = inputCommnad[0];
                var vehicleType = inputCommnad[1];
                var value = double.Parse(inputCommnad[2]);

                if (command == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        DriveVehicle(car, value);
                    }
                    else if (vehicleType == "Truck")
                    {
                        DriveVehicle(truck, value);
                    }
                }
                else if (command == "Refuel")
                {
                    if (vehicleType == "Car")
                    {
                        car.Refuel(value);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(value);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }

        private static void DriveVehicle(Vehicle vehicle, double value)
        {
            bool canTravel = vehicle.Drive(value);

            var result = !canTravel
                ? $"{vehicle.GetType().Name} needs refueling"
                : $"{vehicle.GetType().Name} travelled {value} km";

            Console.WriteLine(result);
        }
    }
}
