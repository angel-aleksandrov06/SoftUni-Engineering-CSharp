namespace PandaExam.Controllers
{
    using PandaExam.Services;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignIn())
            {
                var userId = this.GetUserId();
                var Username = this.usersService.GetUsernameById(userId);
                return this.View(Username, "IndexLoggedIn");
            }
            else
            {
                return this.View();
            }
        }
    }
}
