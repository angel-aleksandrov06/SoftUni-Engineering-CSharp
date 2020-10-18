namespace BattleCards.Services
{
    using BattleCards.Data;
    using BattleCards.ViewModels.Cards;
    using System.Collections.Generic;
    using System.Linq;

    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddCard(AddCardInputModel inputModel)
        {
            var card = new Card
            {
                Attack = inputModel.Attack,
                Health = inputModel.Health,
                Description = inputModel.Description,
                Name = inputModel.Name,
                ImageUrl = inputModel.Image,
                Keyword = inputModel.Keyword,
            };
            this.db.Cards.Add(card);

            this.db.SaveChanges();

            return card.Id;
        }

        public IEnumerable<CardViewModel> GetAll()
        {
            return this.db.Cards.Select(x => new CardViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Attack = x.Attack,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Type = x.Keyword,
                Description = x.Description
            }).ToList();
        }

        public IEnumerable<CardViewModel> GetByUserId(string userId)
        {
            return this.db.UserCards.Where(x => x.UserId == userId).Select(x => new CardViewModel
            {
                Attack = x.Card.Attack,
                ImageUrl = x.Card.ImageUrl,
                Description = x.Card.Description,
                Health = x.Card.Health,
                Name = x.Card.Name,
                Type = x.Card.Keyword,
                Id = x.CardId,

            }).ToList();
        }

        public void AddCardToUserCollection(string userId, int cardId)
        {
            if (this.db.UserCards.Any(x => x.UserId == userId && x.CardId == cardId))
            {
                return;
            }

            this.db.UserCards.Add(new UserCard
            {
                CardId = cardId,
                UserId = userId,
            });

            this.db.SaveChanges();
        }

        public void RemoveCardFromUserCollection(string userId, int cardId)
        {
            var userCard = this.db.UserCards.FirstOrDefault(x => x.UserId == userId && x.CardId == cardId);

            if (userCard == null)
            {
                return;
            }

            this.db.UserCards.Remove(userCard);
            this.db.SaveChanges();
        }
    }
}
