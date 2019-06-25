using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfComands = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < countOfComands; i++)
            {
                string[] inputArticle = Console.ReadLine().Split(", ");

                string title = inputArticle[0];
                string content = inputArticle[1];
                string author = inputArticle[2];

                Article article = new Article(title, content, author);

                articles.Add(article);
            }

            string command = Console.ReadLine();

            if (command == "title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
            }
            else if(command == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
            }
            else if (command == "author")
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, articles));
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }
        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
