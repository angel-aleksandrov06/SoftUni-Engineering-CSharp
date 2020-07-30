namespace PetStore.Mapping
{
    using AutoMapper;

    using PetStore.Models;
    using PetStore.Models.Enumerations;
    using PetStore.ServiceModels.Products.InputModels;
    using PetStore.ServiceModels.Products.OutputModels;
    using SetStore.ViewModels.Product;
    using System;

    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<AddProductInputServiceModel, Product>()
                .ForMember(x => x.ProductType, y => y.MapFrom(z => Enum.Parse(typeof(ProductType), z.ProductType)));
            this.CreateMap<Product, ListAllProductsByProductTypeServiceModel>();
            this.CreateMap<Product, ListAllProductsServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(z => z.ProductType.ToString()));
            this.CreateMap<Product, ListAllProductsByNameServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(z => z.ProductType));
            this.CreateMap<EditProductInputServiceModel, Product>()
                .ForMember(x => x.ProductType, y => y.MapFrom(z => Enum.Parse(typeof(ProductType), z.ProductType)));

            this.CreateMap<ListAllProductsServiceModel, ListAllProductsViewModel>();
        }
    }
}
