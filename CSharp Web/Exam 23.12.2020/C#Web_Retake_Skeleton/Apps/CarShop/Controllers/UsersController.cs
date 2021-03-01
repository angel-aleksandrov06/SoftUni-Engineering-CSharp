namespace CarShop.Controllers
{
    using CarShop.ViewModels.Users;
    using CarShop.Services;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System.ComponentModel.DataAnnotations;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.usersService.GetUserId(input.Username, input.Password);

            if (userId == null)
            {
                return this.Error("Invalid username or password.");
            }

            this.SignIn(userId);

            return this.Redirect("/Cars/All");
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            // Username
            if (string.IsNullOrEmpty(input.Username) || input.Username.Length < 4 || input.Username.Length > 20)
            {
                return this.Error("Username is required and should be between 4 and 20 characters long.");
            }

            if (!this.usersService.IsUsernameAvailable(input.Username))
            {
                return this.Error("Username already taken");
            }

            // Email
            if (string.IsNullOrEmpty(input.Email) || !new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error("Invalid Email.");
            }

            if (!this.usersService.IsEmailAvailable(input.Email))
            {
                return this.Error("Email already taken");
            }

            // Password
            if (string.IsNullOrEmpty(input.Password) || input.Password.Length < 5 || input.Password.Length > 20)
            {
                return this.Error("Password is required and should be between 5 and 20 characters long.");
            }

            if (input.ConfirmPassword != input.Password)
            {
                return this.Error("Passwords do not match.");
            }

            // UserType
            if (string.IsNullOrEmpty(input.UserType))
            {
                return this.Error("Invalid user type. The user type should be Client or Mechanic");
            }
            else if (input.UserType != "Client" && input.UserType != "Mechanic")
            {
                return this.Error("Invalid user type. The user type should be Client or Mechanic");
            }

            this.usersService.Create(input.Username, input.Email, input.Password, input.UserType);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();

            return this.Redirect("/");
        }
    }
}
