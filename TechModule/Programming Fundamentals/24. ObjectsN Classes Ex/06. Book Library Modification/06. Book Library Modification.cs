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
            List<Library> library = new List<Library>();
            Dictionary<string, DateTime> registered = new Dictionary<string, DateTime>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ')
                    .ToArray();
                Book currBook = new Book();
                Library currLib = new Library();

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

                if (registered.ContainsKey(currBookTitle))
                {
                    registered[currBookTitle] = currReleaseDate;
                }
                else
                {
                    bookList.Add(currBook);
                    registered[currBookTitle] = currReleaseDate;
                }

            }

            string dateForCheck = Console.ReadLine();
            var checkDate = DateTime.ParseExact(dateForCheck, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            foreach (var books in registered.Where(x => x.Value > checkDate).OrderBy(x => x.Value).ThenBy(x => x.Key))
            {
                string dateToStr = books.Value.ToString("dd.MM.yyyy");
                Console.WriteLine($"{books.Key} -> {dateToStr}");
            }
        }
    }
}
