namespace Git.Controllers
{
    using Git.Services;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, string repositoryType)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 10)
            {
                return this.Error("Invalid repository name. The repository name should be between 3 and 10 characters.");
            }

            if (string.IsNullOrEmpty(repositoryType))
            {
                return this.Error("Invalid repository type. The repository type should be Public or Private");
            }
            else if (repositoryType != "Public" && repositoryType != "Private")
            {
                return this.Error("Invalid repository type. The repository type should be Public or Private");
            }

            var userId = this.GetUserId();

            this.repositoriesService.Create(name, repositoryType, userId);
            return this.Redirect("/Repositories/All");
        }

        public HttpResponse All()
        {
            var RepositoriesAllViewModel = this.repositoriesService.GetAll();

            return this.View(RepositoriesAllViewModel);
        }
    }
}
