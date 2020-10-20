namespace SULS.Controllers
{
    using SULS.Services;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        // /Home/Index
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignIn())
            {
                var newModelsList = this.problemsService.GetAll();
                return this.View(newModelsList, "IndexLoggedIn");
            }
            else
            {
                return this.View();
            }
        }
    }
}
