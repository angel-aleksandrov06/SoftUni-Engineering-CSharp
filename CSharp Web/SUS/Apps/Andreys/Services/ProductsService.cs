namespace Andreys.Services
{
    using Andreys.Data;
    using Andreys.ViewModels.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext db;

        public ProductsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int add(AddProductInputModel input)
        {
            var IsGenderParsed = Enum.TryParse<Gender>(input.Gender, out Gender gender);
            var IsCategoryParsed = Enum.TryParse<Category>(input.Category, out Category category);

            if (!IsCategoryParsed || !IsGenderParsed)
            {
                return -1;
            }

            var product = new Product
            {
                Name = input.Name,
                Description = input.Description,
                ImageUrl = input.ImageUrl,
                Price = input.Price,
                Category = category,
                Gender = gender,
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();

            return product.Id;
        }

        public bool DeleteProductById(int productId)
        {
            var productToDelete = this.db.Products.Where(x => x.Id == productId).FirstOrDefault();
            if (productToDelete == null)
            {
                return false;
            }

            this.db.Products.Remove(productToDelete);
            this.db.SaveChanges();
            return true;
        }

        public IEnumerable<HomePageViewModel> GetAll()
        {
            var products = this.db.Products.Select(x => new HomePageViewModel 
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ImageUrl = x.ImageUrl
                
            }).ToList();

            return products;
        }

        public ProductDetailsViewModel getProductDetailsById(int id)
        {
            var product = this.db.Products.Where(x => x.Id == id).Select(x => new ProductDetailsViewModel
            {
                Id = x.Id,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                Category = x.Category,
                Gender = x.Gender,
                Name = x.Name
            }).FirstOrDefault();

            return product;
        }
    }
}
