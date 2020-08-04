namespace Cinema.DataProcessor
{
    using System;
    using System.Linq;
    using System.Xml;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ExportDto;
    using Cinema.XMLHelper;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(x => x.Rating >= rating && x.Projections.Any(z => z.Tickets.Count >= 1))
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.Projections.Sum(z => z.Tickets.Sum(y => y.Price)))
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("f2"),
                    TotalIncomes = x.Projections.Sum(z => z.Tickets.Sum(y => y.Price)).ToString("f2"),
                    Customers = x.Projections.SelectMany(z => z.Tickets.Select(c => new
                    {
                        FirstName = c.Customer.FirstName,
                        LastName = c.Customer.LastName,
                        Balance = c.Customer.Balance.ToString("f2")
                    }))
                   .OrderByDescending(x => x.Balance)
                   .ThenBy(x => x.FirstName)
                   .ThenBy(x => x.LastName)
                   .ToArray()
                })
                .Take(10)
                .ToArray();

            var json = JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);

            return json;

        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
                .Where(x => x.Age >= age)
                .OrderByDescending(x => x.Tickets.Sum(z => z.Price))
                .Select(x => new ExportCustomerDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = x.Tickets.Sum(z => z.Price).ToString("f2"),
                    SpentTime = TimeSpan.FromSeconds(x.Tickets.Sum(z => z.Projection.Movie.Duration.TotalSeconds)).ToString(@"hh\:mm\:ss")
                })
                .Take(10)
                .ToArray();

            var xml = XmlConverter.Serialize(customers, "Customers");

            return xml;
        }
    }
}