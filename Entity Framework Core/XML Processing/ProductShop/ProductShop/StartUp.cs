namespace ProductShop
{
    using Microsoft.EntityFrameworkCore;
    using ProductShop.Data;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;
    using ProductShop.XMLHelper;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();
            //EnsureDatabase(db);

            //var userXml = File.ReadAllText("../../../Datasets/users.xml");
            //var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            //var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            //var categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            var result = GetUsersWithProducts(db);

            //File.WriteAllText("../../../Datasets/Result/products-in-range.xml", result);
            //File.WriteAllText("../../../Datasets/Result/users-sold-products.xml", result);
            //File.WriteAllText("../../../Datasets/Result/categories-by-products.xml", result);
            File.WriteAllText("../../../Datasets/Result/users-and-products.xml", result);

            Console.WriteLine(result);
        }

        private static void EnsureDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }

        // Problem 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Users";
            var usersResult = XmlConverter.Deserializer<ImportUserDTO>(inputXml, rootElement);

            //List<User> users = new List<User>();

            //foreach (var importUserDTO in usersResult)
            //{
            //    var user = new User()
            //    {
            //        FirstName = importUserDTO.FirtsName,
            //        LastName = importUserDTO.LastName,
            //        Age = importUserDTO.Age
            //    };

            //    users.Add(user);
            //}

            var users = usersResult
                .Select(u => new User
                {
                    FirstName = u.FirtsName,
                    LastName = u.LastName,
                    Age = u.Age
                })
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        // Problem 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Products";

            var productDtos = XmlConverter.Deserializer<ImportProductDTO>(inputXml, rootElement);

            var products = productDtos.Select(p => new Product 
            {
                Name = p.Name,
                Price = p.Price,
                SellerId = p.SellerId,
                BuyerId = p.BuyerId
            })
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        // Problem 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Categories";

            var categoriesDtos = XmlConverter.Deserializer<ImportCategoryDTO>(inputXml, rootElement);

            //List<Category> categories = new List<Category>();

            //foreach (var dto in categoriesDtos)
            //{
            //    if(dto.Name == null)
            //    {
            //        continue;
            //    }

            //    var category = new Category
            //    {
            //        Name = dto.Name
            //    };

            //    categories.Add(category);
            //}

            var categories = categoriesDtos.Where(x => x.Name != null)
                .Select(x => new Category
                {
                    Name = x.Name
                })
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        // Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            // If provided category or product id, doesn’t exists, skip the whole entry!

            const string rootElement = "CategoryProducts";

            var categoryProductDtos = XmlConverter.Deserializer<ImportCategoryProductDTO>(inputXml, rootElement);

            //var categoryProducts = categoryProductDtos
            //    .Where(x => 
            //    context.Categories.Any(s => s.Id == x.CategoryId) && 
            //    context.Products.Any(s => s.Id == x.ProductId))
            //    .Select(c => new CategoryProduct
            //    {
            //        CategoryId = c.CategoryId,
            //        ProductId = c.ProductId
            //    })
            //    .ToList();

            var categoryProducts = new List<CategoryProduct>();

            foreach (var dto in categoryProductDtos)
            {
                var doesExists = context.Products.Any(x => x.Id == dto.ProductId) && context.Categories.Any(x => x.Id == dto.CategoryId);

                if (doesExists)
                {
                    var categoryProduct = new CategoryProduct
                    {
                        CategoryId = dto.CategoryId,
                        ProductId = dto.ProductId
                    };

                    categoryProducts.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        // Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            const string rootElement = "Products";

            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
               .Select(x => new ExportProductInfoDTO
               {
                   Name = x.Name,
                   Price = x.Price,
                   Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
               })
               .OrderBy(x => x.Price)
               .Take(10)
               .ToList();

            var xml = XmlConverter.Serialize(products, rootElement);

            return xml;
        }

        // Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            const string rootElement = "Users";

            var users = context.Users
                .Where(x => x.ProductsSold.Any())
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new ExportUserSoldProductDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(p => new UserProductDTO
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .Take(5)
                .ToList();

            var xml = XmlConverter.Serialize(users, rootElement);

            return xml;
        }

        // Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string rootElement = "Categories";

            var categories = context.Categories
                .Select(c => new ExportCategoryDTO
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    TotalRevenue = c.CategoryProducts.Sum(x => x.Product.Price),
                    AveragePrice = c.CategoryProducts.Average(p => p.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            var xml = XmlConverter.Serialize(categories, rootElement);

            return xml;
        }

        // Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            const string rootElement = "Users";

            var users = context.Users
                .Include(x => x.ProductsSold) // Works local and in Judge!
                .AsEnumerable()
                .Where(x => x.ProductsSold.Any())
                .Select(x => new ExportUserDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProduct = new ExportProductCountDTO
                    {
                        Count = x.ProductsSold.Count,
                        Products = x.ProductsSold.Select(p => new ExportProductDTO
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(x => x.SoldProduct.Count)
                .Take(10)
                .ToArray();

            var resultDTO = new ExportUserCountDTO
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),
                Users = users
            };

            var xml = XmlConverter.Serialize(resultDTO, rootElement);

            return xml;
        }
    }
}