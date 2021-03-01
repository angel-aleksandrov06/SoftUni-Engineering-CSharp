namespace CarShop.Controllers
{
    using CarShop.Services;
    using CarShop.ViewModels.Cars;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System.Text.RegularExpressions;

    public class CarsController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IUsersService usersService;

        public CarsController(
            ICarsService carsService, 
            IUsersService usersService)
        {
            this.carsService = carsService;
            this.usersService = usersService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var userId = this.GetUserId();

            var isUserMechanic = this.usersService.IsUserMechanic(userId);

            if (isUserMechanic)
            {
                return this.Error("Only Clients can add Cars.");
            }
            else
            {
                return this.View();
            }
        }

        [HttpPost]
        public HttpResponse Add(AddCarInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            // check Model
            if (string.IsNullOrEmpty(input.Model) || input.Model.Length < 5 || input.Model.Length > 20)
            {
                return this.Error("Model is required and should be between 5 and 20 characters long.");
            }

            // check Year
            if (string.IsNullOrEmpty(input.Year))
            {
                return this.Error("Year is required.");
            }

            int year;
            if (int.TryParse(input.Year, out year))
            {
                if (year < 1900)
                {
                    return this.Error("Тhe year cannot be less than 1990.");
                }
                else if (year > 2020)
                {
                    return this.Error("Тhe year cannot be greater than 2020.");
                }
            }
            else
            {
                return this.Error("Year should be number between 1900 and 2020.");
            }

            // Check Image
            if (string.IsNullOrEmpty(input.Image))
            {
                return this.Error("ImageUrl is required.");
            }

            // Check PlateNumber
            if (string.IsNullOrEmpty(input.PlateNumber))
            {
                return this.Error("PlateNumber is required.");
            }

            Regex regex = new Regex(@"^[A-Z]{2}[\d]{4}[A-Z]{2}$");
            Match match = regex.Match(input.PlateNumber);

            if (!match.Success)
            {
                return this.Error("PlateNumber should be 2 Capital English letters, followed by 4 digits, followed by 2 Capital English letters. [ AA1111AA ]");
            }

            var userId = this.GetUserId();

            // Check isUserMechanic
            var isUserMechanic = this.usersService.IsUserMechanic(userId);
            if (isUserMechanic)
            {
                return this.Error("Only Clients can add Cars.");
            }

            this.carsService.Create(input, userId);

            return this.Redirect("/Cars/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            var viewModel = this.carsService.GetAll(userId);

            return this.View(viewModel);
        }
    }
}
