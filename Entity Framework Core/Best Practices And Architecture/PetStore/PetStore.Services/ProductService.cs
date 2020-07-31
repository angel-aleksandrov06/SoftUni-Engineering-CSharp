namespace PetStore.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using PetStore.Common;
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Models.Enumerations;
    using PetStore.ServiceModels.Products.InputModels;
    using PetStore.ServiceModels.Products.OutputModels;
    using PetStore.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductService : IProductService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public ProductService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddProduct(AddProductInputServiceModel model)
        {
            Product product = this.mapper.Map<Product>(model);

            this.dbContext.Products.Add(product);
            this.dbContext.SaveChanges();
        }

        public ICollection<ListAllProductsServiceModel> GetAll()
        {
            var products = this.dbContext.Products
                .ProjectTo<ListAllProductsServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return products;
        }

        public ICollection<ListAllProductsByProductTypeServiceModel> ListAllProductType(string type)
        {
            ProductType productType;

            bool hasParsed = Enum.TryParse<ProductType>(type, true, out productType);

            if (!hasParsed)
            {
                throw new ArgumentException(ExeptionMessages.InvalidProductType);
            }

            var productsServiceModels = this.dbContext.Products
                .Where(p => p.ProductType == productType)
                .ProjectTo<ListAllProductsByProductTypeServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return productsServiceModels;
        }

        public ICollection<ListAllProductsByNameServiceModel> SearchByName(string searchStr, bool caseSensitive)
        {
            ICollection<ListAllProductsByNameServiceModel> products;

            if (caseSensitive)
            {
                products = this.dbContext.Products
                    .Where(x => x.Name.Contains(searchStr))
                    .ProjectTo<ListAllProductsByNameServiceModel>(this.mapper.ConfigurationProvider)
                    .ToList();
            }
            else
            {
                products = this.dbContext.Products
                    .Where(x => x.Name.ToLower().Contains(searchStr))
                    .ProjectTo<ListAllProductsByNameServiceModel>(this.mapper.ConfigurationProvider)
                    .ToList();
            }

            return products;
        }

        public bool RemoveById(string id)
        {
            var productToRemove = this.dbContext
                .Products.FirstOrDefault(x => x.Id == id);

            if (productToRemove == null)
            {
                throw new ArgumentException(ExeptionMessages.ProductByIdNotFound);
            }

            this.dbContext.Products.Remove(productToRemove);
            var rowsAffected = this.dbContext.SaveChanges();

            bool wasDeleted = rowsAffected >= 1;

            return wasDeleted;
        }

        public bool RemoveByName(string name)
        {
            var productToRemove = this.dbContext
                .Products.FirstOrDefault(x => x.Name == name);

            if (productToRemove == null)
            {
                throw new ArgumentException(ExeptionMessages.ProductByNameNotFound);
            }

            this.dbContext.Products.Remove(productToRemove);
            var rowsAffected = this.dbContext.SaveChanges();

            bool wasDeleted = rowsAffected >= 1;

            return wasDeleted;
        }

        
    }
}
