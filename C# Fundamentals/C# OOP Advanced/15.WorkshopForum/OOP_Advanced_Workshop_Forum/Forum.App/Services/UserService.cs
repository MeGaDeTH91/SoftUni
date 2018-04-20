namespace Forum.App.Services
{
    using System;
    using System.Linq;
    using Forum.App.Contracts;
    using Forum.Data;
    using Forum.DataModels;

    public class UserService : IUserService
    {
        private ForumData forumData;
        private ISession session;

        public UserService(ForumData forumData, ISession session)
        {
            this.forumData = forumData;
            this.session = session;
        }

        public User GetUserById(int userId)
        {
            return this.forumData.Users.FirstOrDefault(e => e.Id == userId);
        }

        public string GetUserName(int userId)
        {
            return this.forumData.Users.FirstOrDefault(u => u.Id == userId).Username;
        }

        public bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            User userToLog = this.forumData.Users.FirstOrDefault(x => x.Username == username && x.Password == password);

            if (userToLog == null)
            {
                return false;
            }

            this.session.Reset();
            this.session.LogIn(userToLog);

            return true;
        }

        public bool TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validUsername || !validPassword)
            {
                throw new ArgumentException("Username and Password must be longer than 3 symbols!");
            }

            bool userAlreadyExists = this.forumData.Users.Any(x => x.Username == username);

            if (userAlreadyExists)
            {
                throw new InvalidOperationException("Username taken!");
            }

            int newUserId = this.forumData.Users.LastOrDefault()?.Id + 1 ?? 1;

            User newUser = new User(newUserId, username, password);

            this.forumData.Users.Add(newUser);
            this.forumData.SaveChanges();

            this.TryLogInUser(username, password);

            return true;
        }
    }
}
