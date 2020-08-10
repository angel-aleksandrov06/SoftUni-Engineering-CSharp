namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto;
    using VaporStore.DataProcessor.Dto.Import;
    using VaporStore.XMLHelper;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            var gamesDTOs = JsonConvert.DeserializeObject<ImportGamesDeveloperGenresTagsDTO[]>(jsonString);
            var games = new List<Game>();
            var developers = new List<Developer>();
            var genres = new List<Genre>();
            var tags = new List<Tag>();
            var sb = new StringBuilder();

            foreach (var dto in gamesDTOs)
            {
                Developer dev;
                Genre genre;
                int tagCounter = 0;

                if (!IsValid(dto) || dto.Tags.Length == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                dev = developers.FirstOrDefault(d => d.Name == dto.Developer);
                genre = genres.FirstOrDefault(g => g.Name == dto.Genre);

                var game = new Game()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    ReleaseDate = DateTime.ParseExact(dto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = dev == null ? new Developer() { Name = dto.Developer } : dev,
                    Genre = genre == null ? new Genre() { Name = dto.Genre } : genre
                };

                foreach (var tag in dto.Tags)
                {
                    if (tags.FirstOrDefault(t => t.Name == tag) == null)
                    {
                        var tagtoAdd = new Tag() { Name = tag };
                        game.GameTags.Add(new GameTag { Game = game, Tag = tagtoAdd });
                        tags.Add(tagtoAdd);
                    }
                    else
                    {
                        var foundTag = tags.FirstOrDefault(t => t.Name == tag);
                        game.GameTags.Add(new GameTag { Game = game, Tag = foundTag });
                    }
                    tagCounter++;
                }

                games.Add(game);
                if (dev == null)
                {
                    developers.Add(game.Developer);
                }
                if (genre == null)
                {
                    genres.Add(game.Genre);
                }

                sb.AppendLine(string.Format($"Added {game.Name} ({game.Genre.Name}) with {tagCounter} tags"));
            }

            context.Tags.AddRange(tags);
            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            var sb = new StringBuilder();

            var importUsersDtos = JsonConvert.DeserializeObject<ImportUserCardsDTO[]>(jsonString);

            List<User> users = new List<User>();

            foreach (var importUserDto in importUsersDtos)
            {

                bool isCardValid = true;
                bool isTypeValid = true;

                if (!IsValid(importUserDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (importUserDto.Cards.Count() == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                foreach (var currentCard in importUserDto.Cards)
                {
                    if (!IsValid(currentCard))
                    {
                        sb.AppendLine("Invalid Data");
                        isCardValid = false;
                        break;
                    }
                }

                if (isCardValid ==false)
                {
                    continue;
                }

                User user = new User
                {
                    FullName = importUserDto.FullName,
                    Username = importUserDto.UserName,
                    Email = importUserDto.Email,
                    Age = importUserDto.Age,
                };

                foreach (var currentCard in importUserDto.Cards)
                {
                    if (!Enum.TryParse(typeof(CardType), currentCard.Type, out object cardType))
                    {
                        sb.AppendLine("Invalid Data");
                        isTypeValid = false;
                        break;
                    }

                    Card card = new Card
                    {
                        Number = currentCard.Number,
                        Cvc = currentCard.CVC,
                        Type = (CardType)cardType
                    };

                    user.Cards.Add(card);
                }

                if (isTypeValid == false)
                {
                    continue;
                }

                users.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            var sb = new StringBuilder();

            var importPurchasesDTOs = XmlConverter.Deserializer<ImportPurchaseDto>(xmlString, "Purchases");
            List<Purchase> purchases = new List<Purchase>();
            var games = context.Games.ToArray();
            var cards = context.Cards.ToArray();

            foreach (var importPurchase in importPurchasesDTOs)
            {
                if (!IsValid(importPurchase))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (!Enum.TryParse(typeof(PurchaseType), importPurchase.Type, out object purchaseType))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime date;
                bool isDateValid = DateTime.TryParseExact(importPurchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                if (!isDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Purchase purchase = new Purchase
                {
                    Game = games.FirstOrDefault(x => x.Name == importPurchase.Title),
                    Type = (PurchaseType)purchaseType,
                    ProductKey = importPurchase.ProductKey,
                    Card = cards.FirstOrDefault(x => x.Number == importPurchase.Card),
                    Date = date,
                };

                purchases.Add(purchase);
                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}