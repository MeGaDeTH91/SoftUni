import java.math.BigInteger;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.*;
import java.util.stream.Collectors;

public class p25_BookLibraryModification {
    public static void main(String[] args) throws ParseException {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        ArrayList<Book> bookList = new ArrayList<Book>();
        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd.MM.yyyy");

        Library library = new Library(){{
            setName("Prosveta");
            setBooks(new ArrayList<>());
        }};

        for (int i = 0; i < n; i++)
        {
            String[] input = scanner.nextLine().split("\\s+");

            Book currBook = new Book(){{
                setTitle(input[0]);
                setAuthor(input[1]);
                setPublisher(input[2]);
                setReleaseDate(LocalDate.parse(input[3], formatter));
                setISBN(input[4]);
                setPrice(Double.parseDouble(input[5]));
            }};

            library.getBooks().add(currBook);

        }
        LocalDate minReleaseDate = LocalDate.parse(scanner.nextLine(), formatter);

        Book[] sortedBooks = library.getBooks()
                .stream()
                .filter(a -> a.getReleaseDate().isAfter(minReleaseDate))
                .sorted((a, b) -> {
                int compareResult = a.getReleaseDate().compareTo(b.getReleaseDate());

                    if(compareResult == 0){
                        compareResult = a.getTitle().compareTo(b.getTitle());
                    }

                    return compareResult;
                })
                .toArray(Book[]::new);

        for (Book book : sortedBooks) {
            System.out.printf("%s -> %s%n", book.getTitle(), formatter.format(book.getReleaseDate()));
        }
    }
    static class Book
    {
        private String Title;
        private String Author;
        private String Publisher;
        private LocalDate ReleaseDate;
        private String ISBN;
        private double Price;

        public Book() {
        }

        public Book(String title, String author, String publisher, LocalDate releaseDate, String ISBN, double price) {
            Title = title;
            Author = author;
            Publisher = publisher;
            ReleaseDate = releaseDate;
            this.ISBN = ISBN;
            Price = price;
        }

        public String getTitle() {
            return Title;
        }

        public void setTitle(String title) {
            Title = title;
        }

        public String getAuthor() {
            return Author;
        }

        public void setAuthor(String author) {
            Author = author;
        }

        public String getPublisher() {
            return Publisher;
        }

        public void setPublisher(String publisher) {
            Publisher = publisher;
        }

        public LocalDate getReleaseDate() {
            return ReleaseDate;
        }

        public void setReleaseDate(LocalDate releaseDate) {
            ReleaseDate = releaseDate;
        }

        public String getISBN() {
            return ISBN;
        }

        public void setISBN(String ISBN) {
            this.ISBN = ISBN;
        }

        public double getPrice() {
            return Price;
        }

        public void setPrice(double price) {
            Price = price;
        }
    }
    static class Library
    {
        String Name;
        ArrayList<Book> Books;

        public Library() {
        }

        public Library(String name, ArrayList<Book> books) {
            Name = name;
            Books = books;
        }

        public String getName() {
            return Name;
        }

        public void setName(String name) {
            Name = name;
        }

        public ArrayList<Book> getBooks() {
            return Books;
        }

        public void setBooks(ArrayList<Book> books) {
            Books = books;
        }
    }
}
