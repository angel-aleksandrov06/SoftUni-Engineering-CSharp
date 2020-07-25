namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.Data.SqlClient.Server;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            // DbInitializer.ResetDatabase(db);

            string input = Console.ReadLine();

            int lengthCheck = int.Parse(input);

            Console.WriteLine(CountBooks(db, lengthCheck));
        }

        // Problem 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var bookTitles = context
                .Books
                .AsEnumerable()
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => b.Title)
                .OrderBy(bt => bt)
                .ToList();

            return String.Join(Environment.NewLine, bookTitles);
        }

        // Problem 03
        public static string GetGoldenBooks(BookShopContext context)
        {
            var bookTitles = context
                .Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, bookTitles);
        }

        // Problem 04
        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - ${b.Price:F2}");
            }

            return sb.ToString().Trim();
        }

        // Problem 05
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksNotReleasedIn = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, booksNotReleasedIn);

        }

        // Problem 06
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower()).ToArray();

            var bookTitles = new List<string>();

            foreach (var cat in categories)
            {
                var currCatBookTitles =
                    context.Books.Where(b => b.BookCategories.Any(bc => bc.Category.Name.ToLower() == cat))
                    .Select(b => b.Title)
                    .ToList();

                bookTitles.AddRange(currCatBookTitles);
            }

            bookTitles = bookTitles.OrderBy(bt => bt)
                .ToList();

            return String.Join(Environment.NewLine, bookTitles);
        }

        // Problem 07
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();

            var inputStringArray = date.Split("-").Reverse().ToArray();
            var newStringDate = String.Join("-", inputStringArray);
            DateTime formatedDate = DateTime.Parse(newStringDate);

            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Date < formatedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:F2}");
            }

            return sb.ToString().Trim();
        }

        // Problem 08
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();
            var authors = context.Authors
               .Where(a => a.FirstName.EndsWith(input))
               .Select(a => new
               {
                   FullName = a.FirstName + " " + a.LastName
               })
               .OrderBy(f => f.FullName)
               .ToList();

            foreach (var a in authors)
            {
                sb.AppendLine($"{a.FullName}");
            }

            return sb.ToString().Trim();
        }

        // Problem 09
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitlesContainingString = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(bt => bt)
                .ToList();

            return String.Join(Environment.NewLine, bookTitlesContainingString);
        }

        // Problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var booksWithAuthotsNames = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();

            foreach (var b in booksWithAuthotsNames)
            {
                sb.AppendLine($"{b.Title} ({b.AuthorName})");
            }

            return sb.ToString().Trim();
        }

        // Problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context
                .Books
                .Count(b => b.Title.Length > lengthCheck);

            return booksCount;
        }

        // Problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authorCopies = context
                .Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    BookCopies = a.Books.Sum(b => b.Copies),
                })
                .OrderByDescending(a => a.BookCopies)
                .ToList();

            foreach (var a in authorCopies)
            {
                sb.AppendLine($"{a.FullName} - {a.BookCopies}");
            }

            return sb.ToString().Trim();
        }

        // Problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            var categoryProfits = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks
                        .Select(cb => new
                        {
                            BookProfit = cb.Book.Copies * cb.Book.Price
                        })
                        .Sum(cb => cb.BookProfit)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToList();

            foreach (var c in categoryProfits)
            {
                sb.AppendLine($"{c.Name} ${c.TotalProfit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var categoriesWithMostRecentBooks = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    MostRecentBooks = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Take(3)
                        .Select(cb => new
                        {
                            BookTitle = cb.Book.Title,
                            ReleaseYear = cb.Book.ReleaseDate.Value.Year
                        })
                        .ToList()
                })
                .OrderBy(c => c.CategoryName)
                .ToList();

            foreach (var c in categoriesWithMostRecentBooks)
            {
                sb.AppendLine($"--{c.CategoryName}");

                foreach (var b in c.MostRecentBooks)
                {
                    sb.AppendLine($"{b.BookTitle} ({b.ReleaseYear})");
                }
            }

            return sb.ToString().Trim();
        }

        // Problem 15
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var b in books)
            {
                b.Price += 5;
            }

            context.SaveChanges();
        }

        // Problem 16
        public static int RemoveBooks(BookShopContext context)
        {
            var bookIdsToDelete = context.Books
                .Where(b => b.Copies < 4200).ToList();

            context.RemoveRange(bookIdsToDelete);
            context.SaveChanges();

            return bookIdsToDelete.Count;
        }
    }
}
