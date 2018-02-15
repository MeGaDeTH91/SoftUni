using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _05.Book_Library
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public long ISBN { get; set; }
        public decimal Price { get; set; }

    }
    class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Book> bookList = new List<Book>();
            Library library = new Library()
            {
                Name = "Prosveta",
                Books = bookList
            };
            Dictionary<string, decimal> registered = new Dictionary<string, decimal>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ')
                    .ToArray();
                Book currBook = new Book(); 

                string currBookTitle = input[0];
                string currAuthor = input[1];
                string currPublisher = input[2];
                DateTime currReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                long currISBN = long.Parse(input[4]);
                decimal currPrice = decimal.Parse(input[5]);
                currBook.Title = currBookTitle;
                currBook.Author = currAuthor;
                currBook.Publisher = currPublisher;
                currBook.ReleaseDate = currReleaseDate;
                currBook.ISBN = currISBN;
                currBook.Price = currPrice;

                if (registered.ContainsKey(currAuthor))
                {
                    registered[currAuthor] += currPrice;
                }
                else
                {
                    bookList.Add(currBook);
                    registered[currAuthor] = currPrice;
                }

                library.Books.Add(currBook);
            }
            foreach (var books in registered.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{books.Key} -> {books.Value:F2}");
            }
        }
    }
}
