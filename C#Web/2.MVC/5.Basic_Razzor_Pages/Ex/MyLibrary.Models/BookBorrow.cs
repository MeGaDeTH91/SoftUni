namespace MyLibrary.Models
{
    public class BookBorrow
    {
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int BorrowerId { get; set; }

        public Borrower Borrower { get; set; }
    }
}
