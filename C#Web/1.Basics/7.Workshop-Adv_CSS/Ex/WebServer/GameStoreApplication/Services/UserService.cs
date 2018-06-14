namespace HTTPServer.GameStoreApplication.Services
{
    using GameStore.Data;
    using GameStore.Models;
    using HTTPServer.GameStoreApplication.Utilities;
    using Microsoft.EntityFrameworkCore;
    using Services.Contracts;
    using System.Linq;

    public class UserService : IUserService
    {
        public bool Create(string email, string name, string password)
        {
            using(var db = new GameStoreDbContext())
            {
                bool emailAlreadyExists = db.Users.Any(x => x.Email == email);

                if (emailAlreadyExists)
                {
                    return false;
                }

                bool isThisDudeAdmin = !db.Users.Any();

                string passwordHash = PasswordUtilities.GenerateHash(password);

                User user = new User
                {
                    Email = email,
                    FullName = name,
                    PasswordHash = passwordHash,
                    IsAdmin = isThisDudeAdmin,
                };

                db.Users.Add(user);
                db.SaveChanges();

                return true;
            }
        }

        public bool Find(string email, string password)
        {
            string passwordHash = PasswordUtilities.GenerateHash(password);

            using(var db = new GameStoreDbContext())
            {
                return db.Users.Any(x => x.Email == email && x.PasswordHash == passwordHash);
            }
        }

        public User FindByEmail(string email)
        {
            using (var db = new GameStoreDbContext())
            {
                return db.Users
                    .Include(x => x.Games)
                    .ThenInclude(x => x.Game)
                    .FirstOrDefault(x => x.Email == email);
            }
        }

        public bool IsAdmin(string email)
        {
            using(var db = new GameStoreDbContext())
            {
                return db.Users.Any(x => x.Email == email && x.IsAdmin);
            }
        }
    }
}
