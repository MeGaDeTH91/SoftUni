using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMvc.Domain.Common
{
    public class ValidationConstants
    {
        public class UserConstraints
        {
            public const int UsernameMinLength = 4;
            public const int UsernameMaxLength = 80;

            public const int PasswordMinLength = 4;
            public const int PasswordMaxLength = 100;
        }

        public class NoteConstraints
        {
            public const int TitleMinLength = 4;
            public const int TitleMaxLength = 120;

            public const int ContentMinLength = 4;
        }
    }
}
