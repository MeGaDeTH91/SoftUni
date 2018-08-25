namespace MyBlog.Common
{
    public class ValidationConstants
    {
        public class UserConstraints
        {
            public const int UsernameMinLength = 4;
            public const int UsernameMaxLength = 50;

            public const int FullNameMinLength = 5;
            public const int FullNameMaxLength = 80;
        }

        public class BookConstraints
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 80;

            public const int DescriptionMinLength = 15;
        }

        public class BookCategoryConstraints
        {
            public const int CategoryNameMinLength = 5;
            public const int CategoryNameMaxLength = 80;
        }

        public class BookAuthorConstraints
        {
            public const int FullNameMinLength = 5;
            public const int FullNameMaxLength = 80;

            public const int DescriptionMinLength = 15;
        }

        public class BookAuthorGenreConstraints
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 80;
        }

        public class JokeConstraints
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 80;

            public const int ContentMinLength = 15;
        }

        public class MemeConstraints
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 80;
        }

        public class GameConstraints
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 80;

            public const int DescriptionMinLength = 15;
        }

        public class GameTypeConstraints
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 80;
        }

        public class ReviewConstraints
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 80;

            public const int ContentMinLength = 15;
        }

        public class ReviewTypeConstraints
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 80;
        }

        public class SongConstraints
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 80;

            public const int DescriptionMinLength = 15;
        }

        public class SongGenreConstraints
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 80;
        }

        public class ArtistConstraints
        {
            public const int FullNameMinLength = 5;
            public const int FullNameMaxLength = 80;

            public const int DescriptionMinLength = 15;
        }

        public class ArtistTypeConstraints
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 80;
        }

        public class BrandConstraints
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 80;

            public const int DescriptionMinLength = 15;
        }

        public class BrandTypeConstraints
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 80;
        }

        public class InstrumentConstraints
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 80;

            public const int DescriptionMinLength = 15;
        }

        public class InstrumentTypeConstraints
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 80;
        }

        public class ArticleConstraints
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 80;

            public const int DescriptionMinLength = 15;
        }

        public class ArticleCategoryConstraints
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 80;
        }

        public class ProductConstraints
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 80;

            public const int DescriptionMinLength = 15;
        }

        public class ProductTypeConstraints
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 80;
        }

        public class ErrorMessages
        {
            public const string BookTitleMessage = "Please enter title.";

            public const string GameNameMessage = "Please enter game name.";

            public const string AuthorNameMessage = "Please enter author's name.";

            public const string BorrowerNameMessage = "Please enter borrower's name.";

            public const string ImageURLMessage = "Please enter a valid Image URL.";

            public const string URLMessage = "Please enter a valid URL.";
        }
    }
}
