namespace MyBlog.CommonModels.ViewModels.Users
{
    using System.Collections.Generic;

    public class UserDetailsViewModel
    {
        public string Username { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public bool IsBanned { get; set; }

        public bool EmailConfirmed { get; set; }

        public ICollection<string> UserRoles { get; set; }
    }
}
