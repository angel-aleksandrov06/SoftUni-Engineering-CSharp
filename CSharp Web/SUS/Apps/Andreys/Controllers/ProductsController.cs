namespace Andreys.Controllers
{
    using Andreys.Services;
    using Andreys.ViewModels.Products;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddProductInputModel input)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(input.Name) || input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Error("Invalid product name. The name should be between 4 and 20 characters.");
            }

            if (input.Description.Length > 10)
            {
                return this.Error("Invalid description. The description should be maximum 20 characters.");
            }

            if (input.Price <= 0 )
            {
                return this.Error("Invalid price. The price should be positive number.");
            }

            var productId = this.productsService.add(input);

            if (productId == -1)
            {
                return this.Error("Category or gender are invalid");
            }

            return this.Redirect($"/Products/Details?id={productId}");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            var idAsInt = int.Parse(id);
            var productViewModel = this.productsService.getProductDetailsById(idAsInt);

            if (productViewModel == null)
            {
                return this.Error("Invalid operation.");
            }

            return this.View(productViewModel);
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            var idAsInt = int.Parse(id);
            var isDeleted = this.productsService.DeleteProductById(idAsInt);

            if (!isDeleted)
            {
                return this.Error("Invalid deleting operation.");
            }
            return this.Redirect("/");
        }
    }
}
