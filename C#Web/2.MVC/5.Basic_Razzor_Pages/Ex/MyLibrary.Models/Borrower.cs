namespace MyLibrary.Models
{
    using System.Collections.Generic;

    public class Borrower
    {
        public Borrower()
        {
            this.BorrowedBooks = new List<BookBorrow>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<BookBorrow> BorrowedBooks { get; set; }
    }
}