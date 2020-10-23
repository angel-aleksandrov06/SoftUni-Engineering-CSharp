namespace Andreys.Services
{
    using Andreys.ViewModels.Products;
    using System.Collections.Generic;

    public interface IProductsService
    {
        int add(AddProductInputModel input);

        IEnumerable<HomePageViewModel> GetAll();

        bool DeleteProductById(int productId);

        ProductDetailsViewModel getProductDetailsById(int id);
    }
}
