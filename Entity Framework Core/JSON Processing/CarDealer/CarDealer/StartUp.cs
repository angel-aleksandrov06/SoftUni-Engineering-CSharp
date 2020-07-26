namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CarDealer.Data;
    using CarDealer.DTO.Car;
    using CarDealer.DTO.Customer;
    using CarDealer.DTO.Supply;
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class StartUp
    {
        private static string ResultDirectoryPath = "../../../Datasets/Results";

        public static void Main(string[] args)
        {
            CarDealerContext db = new CarDealerContext();
            InitializeMapper();
            EnsureDirectoryExists(ResultDirectoryPath);

            //ResetDatabase(db);

            // var inputJson = File.ReadAllText("../../../Datasets/suppliers.json");
            // var inputJson = File.ReadAllText("../../../Datasets/parts.json");
            // var inputJson = File.ReadAllText("../../../Datasets/cars.json");
            // var inputJson = File.ReadAllText("../../../Datasets/customers.json");
            // var inputJson = File.ReadAllText("../../../Datasets/sales.json");

            var result = GetTotalSalesByCustomer(db);

            // File.WriteAllText(ResultDirectoryPath + "/ordered-customers.json", result);
            // File.WriteAllText(ResultDirectoryPath + "/toyota-cars.json", result);
            // File.WriteAllText(ResultDirectoryPath + "/local-suppliers.json", result);
            // File.WriteAllText(ResultDirectoryPath + "/cars-and-parts.json", result);
            // File.WriteAllText(ResultDirectoryPath + "/customers-total-sales.json", result);
            // File.WriteAllText(ResultDirectoryPath + "/sales-discounts.json", result);

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

        private static void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
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

        // Problem 13
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        // Problem 14 
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        // Problem 15
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .ProjectTo<OrderedCustomersDTO>()
                .ToArray();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        // Problem 16
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make.ToLower() == "toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ProjectTo<CarMakeToyotaDTO>()
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        // Problem 17 
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers.Where(x => !x.IsImporter).ProjectTo<LocalSuplliersDTO>().ToList();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        // Problem 18
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars.Select(x => new
                    {
                        Name = x.Part.Name,
                        Price = x.Part.Price.ToString("f2")
                    }).ToList()
                }).ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        // Problem 19
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Include(s => s.Sales) // Works local and in Judge!
                .ThenInclude(c => c.Car)
                .ThenInclude(pc => pc.PartCars)
                .ThenInclude(p => p.Part)
                .AsEnumerable()
                .OrderByDescending(z => z.Sales.Sum(k => k.Car.PartCars.Sum(j => j.Part.Price)))
                .ThenByDescending(x => x.Sales.Count)
                .Where(x => x.Sales.Count() > 0)
                .Select(x => new
                {
                    fullName = $"{x.Name}",
                    boughtCars = x.Sales.Count,
                    spentMoney = x.Sales.Sum(c => c.Car.PartCars.Sum(y => y.Part.Price))
                })
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        // Problem 20
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales.Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString("f2"),
                    price = s.Car.PartCars.Sum(x => x.Part.Price).ToString("f"),
                    priceWithDiscount = PriceWithDiscount(s.Car.PartCars.Sum(x => x.Part.Price), s.Discount)
                }).ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }

        private static string PriceWithDiscount(decimal price, decimal discount)
        {
            price *= (1M - discount / 100M);
            return price.ToString("f");
        }
    }
}