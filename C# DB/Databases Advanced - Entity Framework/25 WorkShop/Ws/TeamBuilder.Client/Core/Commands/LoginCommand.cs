using System;
using System.Linq;
using TeamBuilder.Client.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.Client.Core.Commands
{
    public class LoginCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);

            string username = inputArgs[0];
            string password = inputArgs[1];

            if (AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            }

            User user = this.GetUserByCredentials(username, password);

            if(user == null)
            {
                throw new ArgumentException(Constants.ErrorMessages.UserOrPasswordIsInvalid);
            }

            AuthenticationManager.Login(user);

            return $"User {user.Username} successfully logged in!";
        }

        private User GetUserByCredentials(string username, string password)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                var user = db.Users
                    .Where(x => x.Username == username && x.Password == password && x.IsDeleted == false)
                    .FirstOrDefault();

                return user;
            }
        }
    }
}
