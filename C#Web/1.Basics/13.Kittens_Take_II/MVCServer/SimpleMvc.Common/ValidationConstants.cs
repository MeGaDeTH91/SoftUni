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

        public class KittenConstraints
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 80;

            public const int MinAge = 0;
            public const int MaxAge = 40;
        }

        public class BreedConstraints
        {
            public static readonly string[] AllowedBreeds = new string[] { "Street Transcended", "American Shorthair", "Munchkin", "Siamese" };

            public const int NameMinLength = 3;
            public const int NameMaxLength = 80;
        }
    }
}
