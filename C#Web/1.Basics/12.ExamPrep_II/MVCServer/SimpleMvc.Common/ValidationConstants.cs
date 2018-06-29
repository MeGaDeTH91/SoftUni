namespace SimpleMvc.Common
{
    public class ValidationConstants
    {
        public class UserConstraints
        {
            public const int UsernameMinLength = 4;
            public const int UsernameMaxLength = 80;

            public const int PasswordMinLength = 4;
            public const int PasswordMaxLength = 100;

            public const int EmailMinLength = 3;
            public const int EmailMaxLength = 80;
        }

        public class TubeConstraints
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 120;

            public const int AuthorNameMinLength = 3;
            public const int AuthorNameMaxLength = 80;

            public const int DescriptionMinLength = 10;

            public const int YouTubeIdLength = 11;
        }
    }
}
