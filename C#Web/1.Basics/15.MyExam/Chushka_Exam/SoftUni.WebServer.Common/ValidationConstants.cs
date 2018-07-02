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

            public const int FullNameMinLength = 4;
            public const int FullNameMaxLength = 80;

            public static readonly string[] AllowedRoles = new string[] { "User", "Admin" };
        }

        public class ProductConstraints
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 80;

            public const decimal MinPrice = 0.0m;
            public const decimal MaxPrice = decimal.MaxValue;

            public const int DescriptionMinLength = 5;

            public static readonly string[] AllowedProductTypes = new string[] { "Food", "Domestic", "Health", "Cosmetic", "Other" };
        }

        public class ProductTypeConstraints
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 80;
        }
    }
}
