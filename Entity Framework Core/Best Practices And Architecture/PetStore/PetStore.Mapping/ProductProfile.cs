namespace PetStore.Mapping
{
    using AutoMapper;
    using PetStore.Models;
    using PetStore.ServiceModels.Products.InputModels;
    using PetStore.ServiceModels.Products.OutputModels;
<<<<<<< HEAD
    using PetStore.ViewModels.Product;
    using System;
=======
>>>>>>> parent of 0194b46... Add "EditProductInputServiceModel"

    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<AddProductInputServiceModel, Product>();
            this.CreateMap<Product, ListAllProductsByProductTypeServiceModel>();
            this.CreateMap<Product, ListAllProductsServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(z => z.ProductType.ToString()));
            this.CreateMap<Product, ListAllProductsByNameServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(z => z.ProductType));
<<<<<<< HEAD
            this.CreateMap<EditProductInputServiceModel, Product>()
                .ForMember(x => x.ProductType, y => y.MapFrom(z => Enum.Parse(typeof(ProductType), z.ProductType)));

            this.CreateMap<ListAllProductsServiceModel, ListAllProductsViewModel>();
=======
>>>>>>> parent of 0194b46... Add "EditProductInputServiceModel"
        }
    }
}
