namespace PhotoShare.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PrintFriendsListCommand 
    {
        // PrintFriendsList <username>
        public static string Execute(string[] data)
        {
            string username = data[1];
            string result = null;
            // TODO prints all friends of user with given username.
            using (var context = new PhotoShareContext())
            {
                var user = context.Users
                    .Where(u => u.Username == username)
                    .FirstOrDefault();

                var friendships = context.Friendships.ToList();

                if (user == null)
                {
                    throw new ArgumentException($"User {username} not found!");
                }

                var friends = new List<string>();

                foreach (var frship in friendships.Where(x => x.User == user || x.Friend == user))
                {
                    var tempUs1 = frship.UserId;
                    var tempUs2 = frship.FriendId;

                    if(friendships.Any(x => x.UserId == tempUs2 && x.FriendId == tempUs1))
                    {
                        if(tempUs2 != user.Id)
                        {
                            var tempUsername = context.Users.Find(tempUs2).Username;
                            friends.Add(tempUsername);
                        }
                    }
                }

                StringBuilder sb = new StringBuilder();
                if(friends.Count == 0)
                {
                    return $"No friends for this user. :(";
                }
                else
                {
                    sb.AppendLine($"Friends:");

                    sb.Append(string.Join(Environment.NewLine, friends.OrderBy(x => x).Select(x => $"-{x}")));
                    result = sb.ToString().Trim();
                }
            }
            return result;
        }
    }
}
