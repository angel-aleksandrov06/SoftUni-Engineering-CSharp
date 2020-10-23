namespace Andreys.App.Controllers
{
    using Andreys.Services;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignIn())
            {
                var newModelsList = this.productsService.GetAll();
                return this.View(newModelsList, "Home");
            }
            else
            {
                return this.View();
            }
        }
    }
}
