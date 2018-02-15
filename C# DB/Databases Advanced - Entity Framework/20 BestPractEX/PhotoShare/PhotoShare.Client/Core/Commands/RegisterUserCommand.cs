namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Models;
    using Data;
    using System.Linq;

    public class RegisterUserCommand
    {
        // RegisterUser <username> <password> <repeat-password> <email>
        public static string Execute(string[] data)
        {
            string username = data[1];
            string password = data[2];
            string repeatPassword = data[3];
            string email = data[4];

            if(Session.User != null)
            {
                throw new InvalidOperationException($"Invalid credentials!");
            }
            User user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            using (PhotoShareContext context = new PhotoShareContext())
            {
                if(context.Users.Any(x => x.Username == username))
                {
                    throw new InvalidOperationException($"Username {username} is already taken!");
                }
                if (password != repeatPassword)
                {
                    throw new ArgumentException("Passwords do not match!");
                }
                context.Users.Add(user);
                context.SaveChanges();
            }

            return $"User {username} was registered successfully!";
        }
    }
}
