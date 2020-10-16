namespace BattleCards.Controllers
{
    using BattleCards.Data;
    using BattleCards.ViewModels;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System;

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

        public HttpResponse About()
        {
            this.SignIn("niki");
            return this.View();
        }
    }
}
