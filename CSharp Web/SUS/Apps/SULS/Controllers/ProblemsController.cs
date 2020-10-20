namespace SULS.Controllers
{
    using SULS.Services;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, int points)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            // name
            if (string.IsNullOrEmpty(name) || name.Length < 5 || name.Length > 20)
            {
                return this.Error("Name should be between 5 and 20 characters.");
            }

            // points
            if (points < 50 || points > 300)
            {
                return this.Error("Points should be between 50 and 300 characters.");
            }

            this.problemsService.Create(name, (ushort)points);

            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.problemsService.GetById(id);
            return this.View(viewModel);
        }
    }
}
