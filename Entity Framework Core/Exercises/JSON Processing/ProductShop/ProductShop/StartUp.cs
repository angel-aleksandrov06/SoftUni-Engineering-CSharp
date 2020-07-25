namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;
    using ProductShop.Data;
    using ProductShop.DTO.Category;
    using ProductShop.DTO.Product;
    using ProductShop.DTO.User;
    using ProductShop.Models;

    public class StartUp
    {
        private static string ResultDirectoryPath = "../../../Datasets/Results";

        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();
            InitializeMapper();
            EnsureDirectoryExists(ResultDirectoryPath);

            string json = GetUsersWithProducts(db);

            // File.WriteAllText(ResultDirectoryPath + "/products-in-rangeDTO.json", json);
            // File.WriteAllText(ResultDirectoryPath + "/users-sold-products.json", json);
            // File.WriteAllText(ResultDirectoryPath + "/categories-by-products.json", json);
            // File.WriteAllText(ResultDirectoryPath + "/users-and-products.json", json);
            Console.WriteLine(json);
        }

        private static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }

        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<ProductShopProfile>());
        }

        private static void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        // Problem 02
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        // Problem 03
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        // Problem 04
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null)
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        // Problem 05
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Length}";
        }

        // Problem 06
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products.Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ListProductsInRangeDTO>()
                .ToArray();

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        // Problem 07
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users.Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName).ThenBy(u => u.FirstName)
                .ProjectTo<UserWithSoldProductsDTO>()
                .ToArray();

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
        }

        // Problem 08 
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories.ProjectTo<CategoryProductsCountDTO>()
                .OrderByDescending(c => c.ProductsCount).ToArray();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return json;
        }

        // Problem 09
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(x => x.Buyer != null))
                .AsEnumerable()
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count(x => x.Buyer != null),
                        products = u.ProductsSold.Where(x => x.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        }).ToList()
                    }

                })
                .ToList();

            var resultObj = new
            {
                usersCount = users.Count,
                users
            };

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(resultObj, settings);

            return json;
        }
    }
}