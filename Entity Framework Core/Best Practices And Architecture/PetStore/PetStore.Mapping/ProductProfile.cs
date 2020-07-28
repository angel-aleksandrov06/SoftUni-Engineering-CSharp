namespace PetStore.Mapping
{
    using AutoMapper;
    using PetStore.Models;
    using PetStore.ServiceModels.Products.InputModels;
    using PetStore.ServiceModels.Products.OutputModels;

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
        }
    }
}
