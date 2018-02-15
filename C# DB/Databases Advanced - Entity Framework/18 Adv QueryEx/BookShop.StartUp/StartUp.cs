namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                //1.Age Restriction
                //string command = Console.ReadLine();
                //string ageRestricted = GetBooksByAgeRestriction(context, command);
                //Console.WriteLine(ageRestricted);

                //2.Golden Books
                //string result = GetGoldenBooks(context);
                //Console.WriteLine(result);

                //3.Books By Price
                //string result = GetBooksByPrice(context);
                //Console.WriteLine(result);

                //4.Not Released In
                //int year = int.Parse(Console.ReadLine());
                //string result = GetBooksNotRealeasedIn(context, year);
                //Console.WriteLine(result);

                //5.Book Titles By Category
                //string input = Console.ReadLine();
                //string result = GetBooksByCategory(context, input);
                //Console.WriteLine(result);

                //6.Released Before Date
                //string date = Console.ReadLine();
                //string result = GetBooksReleasedBefore(context, date);
                //Console.WriteLine(result);

                //7.Author Search
                //string input = Console.ReadLine();
                //string result = GetAuthorNamesEndingIn(context,input);
                //Console.WriteLine(result);

                //8.Book Search
                //string input = Console.ReadLine();
                //string result = GetBookTitlesContaining(context, input);
                //Console.WriteLine(result);

                //9.Book Search By Author
                //string input = Console.ReadLine();
                //string result = GetBooksByAuthor(context, input);
                //Console.WriteLine(result);

                //10.Count Books
                //int lengthCheck = int.Parse(Console.ReadLine());
                //int result = CountBooks(context, lengthCheck);
                //Console.WriteLine(result);

                //11.Total Book Copies
                //string result = CountCopiesByAuthor(context);
                //Console.WriteLine(result);

                //12.Profit By Category
                //string result = GetTotalProfitByCategory(context);
                //Console.WriteLine(result);

                //13.Most Recent Books
                //string result = GetMostRecentBooks(context);
                //Console.WriteLine(result);

                //14.Most Recent Books
                //IncreasePrices(context);

                //15.Remove Books
                //int deletedBooks = RemoveBooks(context);
                //Console.WriteLine($"{deletedBooks} books were deleted");
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context.Books.OrderBy(x => x.Title).ToList();

            string result = string.Empty;

            switch (command.ToLower())
            {
                case "minor":
                   var minors = context.Books
                        .Where(x => x.AgeRestriction == AgeRestriction.Minor)
                        .OrderBy(x => x.Title)
                        .Select(x => x.Title)
                        .ToList();

                    result = string.Join(Environment.NewLine, minors);

                    break;
                case "teen":
                    var teens = context.Books
                        .Where(x => x.AgeRestriction == AgeRestriction.Teen)
                        .OrderBy(x => x.Title)
                        .Select(x => x.Title)
                        .ToList();

                    result = string.Join(Environment.NewLine, teens);

                    break;
                case "adult":
                    var adults = context.Books
                        .Where(x => x.AgeRestriction == AgeRestriction.Adult)
                        .OrderBy(x => x.Title)
                        .Select(x => x.Title)
                        .ToList();

                    result = string.Join(Environment.NewLine, adults);
                    break;
                default:
                    break;
            }
            return result;
        }

        //2-ри начин за 1.AgeRestriction
        //public static string GetBooksByAgeRestriction(BookShopContext db, string command)
        //{
        //    var titles = db.Books
        //        .OrderBy(b => b.Title)
        //        .Where(b => b.AgeRestriction
        //                     .ToString()
        //                     .ToLower()
        //                     .Equals(command, StringComparison.InvariantCultureIgnoreCase))
        //        .Select(b => b.Title)
        //        .ToList();
        //    var result = String.Join(Environment.NewLine, titles);
        //    return result;
        //}

        public static string GetGoldenBooks(BookShopContext context)
        {
            string result = string.Empty;

            var books = context.Books
                .OrderBy(x => x.BookId)
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .Select(x => x.Title)
                .ToList();

            result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            string result = string.Empty;

            var books = context.Books
                .OrderByDescending(x => x.Price)
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    BookTitle = x.Title,
                    BookPrice = x.Price
                }).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var b in books)
            {
                sb.Append($"{b.BookTitle} - ${b.BookPrice:F2}" + Environment.NewLine);
            }

            result = sb.ToString();

            return result;
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            string result = string.Empty;

            var books = context.Books
                .OrderBy(x => x.BookId)
                .Where(x => x.ReleaseDate.Value.Year != year)
                .Select(x => x.Title)
                .ToList();

            result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] args = input.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string result = string.Empty;

            var books = context.Books
                .OrderBy(x => x.Title)
                .Where(b => b.BookCategories
                .Any(bc => args.Contains(bc.Category.Name.ToLower())))
                .Select(x => x.Title)
                .ToList();

            result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            string result = string.Empty;

            DateTime releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .OrderByDescending(x => x.ReleaseDate)
                .Where(x => x.ReleaseDate < releaseDate)
                .Select(x => new
                {
                    BookTitle = x.Title,
                    BookEdition = x.EditionType,
                    BookPrice = x.Price
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var b in books)
            {
                sb.Append($"{b.BookTitle} - {b.BookEdition} - ${b.BookPrice:F2}" + Environment.NewLine);
            }

            result = sb.ToString();

            return result;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            string result = string.Empty;

            var authors = context.Authors
                 .Where(x => x.FirstName.ToLower().EndsWith(input.ToLower()))
                 .Select(x => $"{x.FirstName} {x.LastName}")
                 .OrderBy(x => x)
                 .ToList();

            result = string.Join(Environment.NewLine, authors);

            //StringBuilder sb = new StringBuilder();

            //foreach (var auth in authors)
            //{
            //    sb.Append(auth.Name + Environment.NewLine);
            //}

            //result = sb.ToString();

            return result;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string result = string.Empty;

            var books = context.Books
                .OrderBy(x => x.Title)
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .ToList();

            result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            string result = string.Empty;

            var books = context.Books
                .OrderBy(x => x.BookId)
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(x => $"{x.Title} ({x.Author.FirstName} {x.Author.LastName})")
                .ToList();

            result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int bookNumber = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return bookNumber;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            string result = string.Empty;

            var authors = context.Authors
                .Select(x => new {FullName= $"{x.FirstName} {x.LastName}", Copies = x.Books.Sum(y => y.Copies)})
                .OrderByDescending(x => x.Copies)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var auth in authors)
            {
                sb.Append($"{auth.FullName} - {auth.Copies}" + Environment.NewLine);
            }

            result = sb.ToString();

            return result;
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            string result = string.Empty;

            var categories = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    CategoryProfit = x.CategoryBooks.Sum(y => y.Book.Copies * y.Book.Price)
                })
                .OrderByDescending(x => x.CategoryProfit)
                .ThenBy(x => x.CategoryName)
                .ToList();

            result = string.Join(Environment.NewLine, categories.Select(x => $"{x.CategoryName} ${x.CategoryProfit}"));

            return result;
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            string result = string.Empty;

            var categories = context.Categories
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    CategoryName = x.Name,
                    Books = x.CategoryBooks.Select(b => b.Book).OrderByDescending(rd => rd.ReleaseDate)
                    .Take(3).ToList()
                })
                .ToList();

            result = string.Join(Environment.NewLine, categories.Select(x => $"--{x.CategoryName}{Environment.NewLine}{string.Join(Environment.NewLine, x.Books.Select(y => $"{y.Title} ({y.ReleaseDate.Value.Year})"))}"));

            return result;
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var b in books)
            {
                b.Price += 5;
            }
            context.SaveChanges();
        }

        //2-ри начин за IncreasePrices
        //public static void IncreasePrices(BookShopContext context)
        //{
        //    context.Books
        //        .Where(x => x.ReleaseDate.Value.Year < 2010)
        //        .ToList()
        //        .ForEach(x => x.Price += 5);

        //    context.SaveChanges();
        //}

        public static int RemoveBooks(BookShopContext context)
        {
            int count = 0;

            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            count = books.Count;

            context.Books.RemoveRange(books);

            context.SaveChanges();

            return count;
        }
    }
}
