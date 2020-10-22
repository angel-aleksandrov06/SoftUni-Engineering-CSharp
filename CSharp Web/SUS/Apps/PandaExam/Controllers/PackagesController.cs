namespace PandaExam.Controllers
{
    using PandaExam.Data;
    using PandaExam.Services;
    using PandaExam.ViewModels.Packages;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System.Linq;

    public class PackagesController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IPackagesService packagesService;

        public PackagesController(IUsersService usersService, IPackagesService packagesService)
        {
            this.usersService = usersService;
            this.packagesService = packagesService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            var allUsers = this.usersService.GetAllUsernames();
            return this.View(allUsers);
        }

        [HttpPost]
        public HttpResponse Create(CreateInputModel input)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(input.Description) || input.Description.Length < 5 || input.Description.Length > 20)
            {
                return this.Error("Description is required and should be between 5 and 20 characters!");
            }

            if (input.Weight <= 0)
            {
                return this.Error("Weigth should be positive floating number.");
            }

            if (string.IsNullOrEmpty(input.RecipientName))
            {
                return this.Error("RecipientName is required!");
            }

            this.packagesService.Create(input);

            return this.Redirect("/Packages/Pending");
        }

        public HttpResponse Pending()
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            var packages = this.packagesService.GetAllByStatus(PackageStatus.Pending).Select(x => new PackageViewModel
            {
                Description = x.Description,
                Weight = x.Weigth,
                Id = x.Id,
                ShippingAddress = x.ShippingAddress,
                RecipientName = x.Recipient.Username,
            }).ToList();

            return this.View(new PackagesListViewModel { Packages = packages });
        }

        public HttpResponse Delivered()
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            var packages = this.packagesService.GetAllByStatus(PackageStatus.Delivered).Select(x => new PackageViewModel
            {
                Description = x.Description,
                Weight = x.Weigth,
                Id = x.Id,
                ShippingAddress = x.ShippingAddress,
                RecipientName = x.Recipient.Username,
            }).ToList();

            return this.View(new PackagesListViewModel { Packages = packages });
        }

        public HttpResponse Deliver(string id)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            packagesService.Deliver(id);

            return this.Redirect("/Packages/Delivered");
        }
    }
}
