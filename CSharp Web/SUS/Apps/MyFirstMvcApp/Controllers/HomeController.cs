namespace BattleCards.Controllers
{
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (!this.IsUserSignIn())
            {
                return this.View();
            }

            return this.Redirect("/Cards/All");
        }
    }
}
