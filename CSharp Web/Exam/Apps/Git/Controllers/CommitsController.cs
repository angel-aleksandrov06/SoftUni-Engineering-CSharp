namespace Git.Controllers
{
    using Git.Services;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;

        public CommitsController(ICommitsService commitsService)
        {
            this.commitsService = commitsService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var commitCreateViewModel = this.commitsService.GetRepositoryInfo(id);
            return this.View(commitCreateViewModel);
        }

        [HttpPost]
        public HttpResponse Create(string description, string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(description) || description.Length < 5)
            {
                return this.Error("Invalid description. The description should be at least 5 characters.");
            }

            var userId = this.GetUserId();

            this.commitsService.Create(description, id, userId);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            var viewModel = this.commitsService.GetAll(userId);
            return this.View(viewModel);
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            this.commitsService.Detele(id, userId);
            return this.Redirect("/Commits/All");
        }
    }
}
