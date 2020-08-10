namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;
    using VaporStore.XMLHelper;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var result = context.Genres
				.ToList()
				.Where(x => genreNames.Contains(x.Name) == true)
				.Select(x => new
				{
					Id = x.Id,
					Genre = x.Name,
					Games = x.Games
						.Where(g => g.Purchases.Count > 0)
						.Select(g => new
						{
							Id = g.Id,
							Title = g.Name,
							Developer = g.Developer.Name,
							Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name)),
							Players = g.Purchases.Count
						})
						.OrderByDescending(g => g.Players)
						.ThenBy(g => g.Id)
						.ToList(),
					TotalPlayers = x.Games.SelectMany(g => g.Purchases).Count(),
				})
				.OrderByDescending(x => x.TotalPlayers)
				.ThenBy(x => x.Id)
				.ToList();

			var json = JsonConvert.SerializeObject(result, Formatting.Indented);
			return json;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			var result = context.Users
				.ToList()
				.Where(u => u.Cards.SelectMany(c => c.Purchases).Count() > 0)
				.Select(u => new ExportUserdto
				{
					Username = u.Username,
					Purchases = u.Cards.SelectMany(c => c.Purchases)
						.Where(p => p.Type.ToString() == storeType)
						.Select(p => new PurchasesDto
						{
							Card = p.Card.Number,
							Cvc = p.Card.Cvc,
							Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
							Game = new GameDto
							{
								Title = p.Game.Name,
								Genre = p.Game.Genre.Name,
								Price = p.Game.Price
							}
						})
						.OrderBy(p => DateTime.Parse(p.Date)).ToList(),
					TotalMoneySpent = u.Cards.SelectMany(c => c.Purchases)
						.Where(p => p.Type.ToString() == storeType).Sum(p => p.Game.Price)
				})
				.Where(u => u.Purchases.Count > 0)
				.OrderByDescending(u => u.TotalMoneySpent)
				.ThenBy(u => u.Username)
				.ToList();

			var xml = XmlConverter.Serialize(result, "Users");

			return xml;
		}
	}
}