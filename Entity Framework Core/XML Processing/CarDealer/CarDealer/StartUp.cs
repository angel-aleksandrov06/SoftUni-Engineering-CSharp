namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.DTO;
    using CarDealer.Models;
    using CarDealer.XMLHelper;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //ResetDatabase(db);

            //var inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //var inputXml = File.ReadAllText("../../../Datasets/parts.xml");
            //var inputXml = File.ReadAllText("../../../Datasets/cars.xml");
            //var inputXml = File.ReadAllText("../../../Datasets/customers.xml");
            //var inputXml = File.ReadAllText("../../../Datasets/sales.xml");

            var result = GetLocalSuppliers(db);
            
            //File.WriteAllText("../../../ExportedXmlFiles/sales-discounts.xml", result);
            //File.WriteAllText("../../../ExportedXmlFiles/cars.xml", result);
            //File.WriteAllText("../../../ExportedXmlFiles/bmw-cars.xml", result);
            File.WriteAllText("../../../ExportedXmlFiles/local-suppliers.xml", result);

            Console.WriteLine(result);
        }

        private static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }

        // Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Suppliers";

            var suppliersDTOs = XmlConverter.Deserializer<ImportSuppliersDTO>(inputXml, rootElement);

            var suppliers = suppliersDTOs.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter
            })
                .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        // Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Parts";

            var partDtos = XmlConverter.Deserializer<ImportPartDTO>(inputXml, rootElement);

            var parts = partDtos
                .Where(x => context.Suppliers.Any(s => s.Id == x.SupplierId))
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId
                })
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        // Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Cars";

            var carDTOs = XmlConverter.Deserializer<ImportCarDTO>(inputXml, rootElement);
            List<Car> cars = new List<Car>();

            foreach (var carDto in carDTOs)
            {
                var uniqueParts = carDto.Parts.Select(s => s.Id).Distinct().ToArray();
                var realParts = uniqueParts.Where(id => context.Parts.Any(i => i.Id == id));

                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance,
                    PartCars = realParts.Select(id => new PartCar
                    {
                        PartId = id
                    })
                    .ToArray()
                };

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        // Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Customers";

            var customerDTOs = XmlConverter.Deserializer<ImportCustomerDTO>(inputXml, rootElement);

            var customers = customerDTOs.Select(x => new Customer
            {
                Name = x.Name,
                IsYoungDriver = x.IsYoungDriver,
                BirthDate = DateTime.Parse(x.BirthDate)
            })
                .ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        // Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Sales";

            var salesDTOs = XmlConverter.Deserializer<ImportSalesDTO>(inputXml, rootElement);

            var sales = salesDTOs.Where(x => context.Cars.Any(y => y.Id == x.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount
                })
                .ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        // Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .Select(x => new ExportCarsDTO
                {
                    Make = x.Make,
                    Model = x.Model,
                    TraveledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            var xml = XmlConverter.Serialize(cars, "cars");

            return xml;
        }

        // Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make.ToLower() == "bmw")
                .Select(x => new ExportBMWCar
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToArray();

            var xml = XmlConverter.Serialize(cars, "cars");

            return xml;
        }

        // Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new ExportLocalSuppliersDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToArray();

            var xml = XmlConverter.Serialize(suppliers, "suppliers");

            return xml;
        }

        // Problem19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var result = context.Sales
                .Select(x => new ExportSaleDTO
                {
                    Car = new ExportCarDTO
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(z => z.Part.Price),
                    PriceWithDiscount = x.Car.PartCars.Sum(z => z.Part.Price) -
                                        x.Car.PartCars.Sum(z => z.Part.Price) * x.Discount /100
                })
                .ToArray();

            var xml = XmlConverter.Serialize(result, "sales");

            return xml;
        }
    }
}