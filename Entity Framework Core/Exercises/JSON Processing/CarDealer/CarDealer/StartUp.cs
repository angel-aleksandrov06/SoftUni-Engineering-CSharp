namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTO.Car;
    using CarDealer.Models;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext db = new CarDealerContext();
            InitializeMapper();

            // var inputJson = File.ReadAllText("../../../Datasets/suppliers.json");
            // var inputJson = File.ReadAllText("../../../Datasets/parts.json");
            var inputJson = File.ReadAllText("../../../Datasets/cars.json");

            //ResetDatabase(db);
            var result = ImportCars(db, inputJson);

            Console.WriteLine(result);
        }

        private static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }

        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<CarDealerProfile>());
        }

        // Problem 10
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            Supplier[] suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        // Problem 11
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            Part[] parts = JsonConvert.DeserializeObject<Part[]>(inputJson);

            var supplierIds = context.Suppliers.Select(s => s.Id).ToList();

            Part[] filteredParts = parts.Where(p => supplierIds.Contains(p.SupplierId)).ToArray();

            context.Parts.AddRange(filteredParts);
            context.SaveChanges();

            return $"Successfully imported {filteredParts.Length}.";
        }

        // Problem 12
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<ImportCarDTO[]>(inputJson);

            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            foreach (var carDto in carsDto)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (var part in carDto.PartsId.Distinct())
                {
                    var carPart = new PartCar()
                    {
                        PartId = part,
                        Car = car,
                    };

                    carParts.Add(carPart);
                }
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }
    }
}