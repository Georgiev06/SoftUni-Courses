using System;
using System.Linq;
using System.Collections.Generic;

namespace ObjectsAndClasses
{
    class MainClass
    {
        public static void Main()
        {
            int numberOfArticles = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] command = Console.ReadLine()
                   .Split(", ", StringSplitOptions.RemoveEmptyEntries);


                string title = command[0];
                string content = command[1];
                string author = command[2];

                var newArticle = new Article(title, content, author);

                articles.Add(newArticle);
            }

            string orderBy = Console.ReadLine();

            if (orderBy == "title")
            {
                articles = articles.OrderBy(t => t.Title)
                    .ToList();
                    
            }
            else if (orderBy == "content")
            {
                articles = articles.OrderBy(c => c.Content)
                    .ToList();     
            }
            else if (orderBy == "author")
            {
                articles = articles.OrderBy(a => a.Author)
                    .ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, articles));
        }

        public class Article
        {
            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }

            public object Title { get; set; }

            public object Content { get; set; }

            public object Author { get; set; }

            public override string ToString()
            {
                return $"{this.Title} - {this.Content}: {this.Author}";
            }
        }
    }
}