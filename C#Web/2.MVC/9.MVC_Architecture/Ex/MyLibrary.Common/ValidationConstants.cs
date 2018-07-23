namespace MyLibrary.Common
{
    public class ValidationConstants
    {
        public class BookConstants
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 80;
        }

        public class MovieConstants
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 80;
        }

        public class AuthorConstants
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 80;
        }
        public class DirectorConstants
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 80;
        }
        public class BorrowerConstants
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 80;
        }
        public class ErrorMessages
        {
            public const string BookTitleMessage = "Please enter title.";

            public const string AuthorNameMessage = "Please enter author's name.";

            public const string BorrowerNameMessage = "Please enter borrower's name.";

            public const string URLMessage = "Please enter valid Image URL.";
        }
    }
}
