using System;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] articleArgs = Console.ReadLine().Split(", ");

            string title = articleArgs[0];
            string content = articleArgs[1];
            string author = articleArgs[2];

            Article article = new Article(title, content, author);

            int countOfComands = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfComands; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(": ");

                string command = commandArgs[0];

                if(command == "Edit")
                {
                    string curreContent = commandArgs[1];
                    article.Edit(curreContent);
                }
                else if (command == "ChangeAuthor")
                {
                    string curreAuthor = commandArgs[1];
                    article.ChangeAuthor(curreAuthor);
                }
                else if (command == "Rename")
                {
                    string currentTitle = commandArgs[1];
                    article.Rename(currentTitle);
                }
            }

            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
        }
    }

    class Article
    {
        public string Title { get; set;  } 
        public string Content { get; set;  } 
        public string Author { get; set;  } 

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

    }
}
