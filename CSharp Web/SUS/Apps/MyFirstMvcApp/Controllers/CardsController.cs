﻿namespace BattleCards.Controllers
{
    using BattleCards.Data;
    using BattleCards.ViewModels;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System.Linq;

    public class CardsController : Controller
    {
        private ApplicationDbContext db;

        public CardsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd(string attack, string health, string description, string name, string image, string keyword)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (this.Request.FormData["name"].Length < 5)
            {
                return this.Error("Name should be at least 5 characters long.");
            }

            this.db.Cards.Add(new Card
            {
                Attack = int.Parse(attack),
                Health = int.Parse(health),
                Description = description,
                Name = name,
                ImageUrl = image,
                Keyword = keyword,
            });

            this.db.SaveChanges();

            return this.Redirect("/Cards/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            var cardsViewModel = this.db.Cards.Select(x => new CardViewModel
            {
                Name = x.Name,
                Attack = x.Attack,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Type = x.Keyword,
                Description = x.Description
            }).ToList();

            return this.View(cardsViewModel);
        }
        public HttpResponse Collection()
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }
    }
}
