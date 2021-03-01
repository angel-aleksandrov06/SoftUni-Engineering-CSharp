namespace CarShop.Controllers
{
    using CarShop.Services;
    using CarShop.ViewModels.Issues;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class IssuesController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IUsersService usersService;
        private readonly IIssuesService issuesService;

        public IssuesController(
            ICarsService carsService,
            IUsersService usersService,
            IIssuesService issuesService)
        {
            this.carsService = carsService;
            this.usersService = usersService;
            this.issuesService = issuesService;
        }

        public HttpResponse Add(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View(carId);
        }

        [HttpPost]
        public HttpResponse Add(AddIssueInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(input.Description) || input.Description.Length < 5)
            {
                return this.Error("Description is required and should have minimum 5 characters.");
            }

            if (string.IsNullOrEmpty(input.carId))
            {
                return this.Error("carId is required.");
            }

            this.issuesService.Add(input);

            return this.Redirect("/Issues/CarIssues?carId=" + input.carId);
        }

        public HttpResponse CarIssues(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.issuesService.GetAllByCarId(carId);

            return this.View(viewModel);
        }

        public HttpResponse Delete(string issueId, string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var isDeleted = this.issuesService.Delete(issueId, carId);

            if (!isDeleted)
            {
                return this.Error("There is no such issue.");
            }
            
            return this.Redirect("/Issues/CarIssues?CarId=" + carId);
        }

        public HttpResponse Fix(string issueId, string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            var isUserMechanic = this.usersService.IsUserMechanic(userId);

            if (!isUserMechanic)
            {
                return this.Error("Only users that are mechanics can fix issues.");
            }

            var isFixed = this.issuesService.Fix(issueId);

            if (!isFixed)
            {
                return this.Error("There is no such issue.");
            }

            return this.Redirect("/Issues/CarIssues?CarId=" + carId);
        }
    }
}
