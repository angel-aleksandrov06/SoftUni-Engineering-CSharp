namespace PandaExam.Controllers
{
    using PandaExam.Services;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System.Collections.Generic;

    public class PackagesController : Controller
    {
        private readonly IUsersService usersService;

        public PackagesController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Create()
        {
            var allUsers = this.usersService.GetAllUsers();
            return this.View(allUsers);
        }
    }
}
