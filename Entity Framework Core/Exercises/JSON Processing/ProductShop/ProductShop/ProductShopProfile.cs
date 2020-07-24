using AutoMapper;
using ProductShop.DTO.Category;
using ProductShop.DTO.Product;
using ProductShop.DTO.User;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<Product, ListProductsInRangeDTO>()
                .ForMember(x => x.SellerName, y => y.MapFrom(z => z.Seller.FirstName + " " + z.Seller.LastName));

            this.CreateMap<Product, UserSoldProductDTO>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.Buyer.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.Buyer.LastName));

            this.CreateMap<User, UserWithSoldProductsDTO>()
                .ForMember(x => x.SoldProducts, y => y.MapFrom(z => z.ProductsSold.Where(x => x.Buyer != null)));

            this.CreateMap<Category, CategoryProductsCountDTO>()
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.ProductsCount, y => y.MapFrom(z => z.CategoryProducts.Count))
                .ForMember(x => x.AveragePrice, y => y.MapFrom(z => z.CategoryProducts.Average(k => k.Product.Price).ToString("f2")))
                .ForMember(x => x.TotalRevenue, y => y.MapFrom(z => z.CategoryProducts.Sum(k => k.Product.Price).ToString("f2")));
        }
    }
}
