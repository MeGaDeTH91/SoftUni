namespace GameStore.GameStoreApplication.Common
{
    using System;

    public class ValidationConstants
    {
        
        public class AccountConstraints
        {
            public const int EmailMinLength = 3;
            public const int EmailMaxLength = 40;

            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;

            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 50;
        }

        public class GameConstraints
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 100;

            public const int VideoLength = 11;

            public const int DescriptionMinLength = 20;
            public const int DescriptionHomeMaxLength = 300;

            public const int StringMaxLength = 2048;

            public const int PriceMinimum = 1;
            public const int SizeMinimum = 1;
        }
    }
}
