namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using BookShop.XMLHelper;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var mostCraziestAuthors = context.Authors.Select(a => new
            {
                AuthorName = a.FirstName + " " + a.LastName,
                Books = a.AuthorsBooks
                .OrderByDescending(x => x.Book.Price)
                .Select(ab => new
                {
                    BookName = ab.Book.Name,
                    BookPrice = ab.Book.Price.ToString("f2")
                })
                .ToArray()
            })
            .ToArray()
            .OrderByDescending(x => x.Books.Length)
            .ThenBy(x => x.AuthorName)
            .ToArray();

            string json = JsonConvert.SerializeObject(mostCraziestAuthors, Formatting.Indented);

            return json;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var sb = new StringBuilder();
                
            var oldestBooks = context.Books
                .Where(x => x.PublishedOn < date && x.Genre == Genre.Science)
                .ToArray()
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Select(x => new ExportBookDTO
                {
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d",CultureInfo.InvariantCulture),
                    Pages = x.Pages
                })
                .Take(10)
                .ToArray();

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportBookDTO[]), new XmlRootAttribute("Books"));
            //XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            //namespaces.Add(string.Empty, string.Empty);

            //using var stringWriter = new StringWriter(sb);

            //xmlSerializer.Serialize(stringWriter, oldestBooks, namespaces);

            return XmlConverter.Serialize(oldestBooks, "Books").TrimEnd();
        }
    }
}