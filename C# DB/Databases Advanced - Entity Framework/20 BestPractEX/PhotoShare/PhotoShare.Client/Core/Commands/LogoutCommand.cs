using PhotoShare.Data;
using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoShare.Client.Core.Commands
{
    public class LogoutCommand
    {
        public static string Execute(string[] data)
        {

            if(Session.User == null)
            {
                throw new InvalidOperationException($"You should log in first in order to logout.");
            }
            string username = Session.User.Username;
            Session.User = null;

            return $"User {username} successfully logged out!";
        }
    }
}
