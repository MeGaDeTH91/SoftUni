using System;
using TeamBuilder.Client.Utilities;
using TeamBuilder.Models;

namespace TeamBuilder.Client.Core
{
    public class AuthenticationManager
    {
        private static User currentUser;

        public static void Login(User user)
        {
            if (currentUser != null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            }
            currentUser = user;
        }

        public static void Logout()
        {
            if (currentUser == null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
            }
            currentUser = null;
        }

        public static void Authorize()
        {
            if(currentUser == null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
            }
        }

        public static bool IsAuthenticated()
        {
            return currentUser != null;
        }

        public static User GetCurrentUser()
        {
            if (currentUser == null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
            }
            return currentUser;
        }
    }
}
