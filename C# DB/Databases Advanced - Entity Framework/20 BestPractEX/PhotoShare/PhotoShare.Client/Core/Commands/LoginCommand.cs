namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class LoginCommand
    {
        public static string Execute(string[] data)
        {

            string username = data[1];
            string password = data[2];

            var user = new User();

            using (var context = new PhotoShareContext())
            {
                user = context.Users
                    .Where(x => x.Username == username)
                    .FirstOrDefault();

            }
            if (user == null || user.Password != password)
            {
                throw new ArgumentException($"Invalid username or password!");
            }
            if (Session.User != null)
            {
                throw new ArgumentException($"You should logout first!");
            }
            if(user.IsDeleted == true)
            {
                throw new ArgumentException("This user is deleted.");
            }

            Session.User = user;

            return $"User {username} successfully logged in!";
        }
    }
}
