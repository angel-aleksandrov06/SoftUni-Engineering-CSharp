namespace SULS.Controllers
{
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class HomeController : Controller
    {
        // /Home/Index
        [HttpGet("/")]
        public HttpResponse Index()
        {
            return this.View();
        }
    }
}
