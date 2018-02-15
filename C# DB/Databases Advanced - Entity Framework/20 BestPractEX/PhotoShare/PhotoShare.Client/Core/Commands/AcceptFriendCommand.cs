namespace PhotoShare.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class AcceptFriendCommand
    {
        // AcceptFriend <username1> <username2>
        public static string Execute(string[] data)
        {
            string username1 = data[1];
            string username2 = data[2];

            using (var context = new PhotoShareContext())
            {
                var user1 = context.Users
                    .Include(x => x.FriendsAdded)
                    .Include(x => x.AddedAsFriendBy)
                    .Where(x => x.Username == username1)
                    .FirstOrDefault();

                var user2 = context.Users
                    .Include(x => x.FriendsAdded)
                    .Include(x => x.AddedAsFriendBy)
                    .Where(x => x.Username == username2)
                    .FirstOrDefault();

                if(username1 == username2)
                {
                    throw new ArgumentException("Usernames must be different!");
                }

                if (user1 == null)
                {
                    throw new ArgumentException($"{username1} not found!");
                }
                if (user2 == null)
                {
                    throw new ArgumentException($"{username2} not found!");
                }
                if(Session.User == null || Session.User.Username != username1)
                {
                    throw new ArgumentException("Invalid Credentials!");
                }

                bool alreadyFriends = user1.FriendsAdded.Any(x => x.Friend == user2) &&
                    user1.AddedAsFriendBy.Any(x => x.Friend == user1);
                bool noSuchRequest = !user2.FriendsAdded.Any(x => x.Friend == user1);

                if(alreadyFriends)
                {
                    throw new ArgumentException($"{username2} is already a friend to {username1}");
                }

                if(noSuchRequest)
                {
                    throw new ArgumentException($"{username2} has not added {username1} as a friend");
                }
                                
                Friendship friendship = new Friendship()
                {
                    User = user1,
                    Friend = user2
                };

                user1.FriendsAdded.Add(friendship);
                context.SaveChanges();
            }

            return $"{username1} accepted {username2} as a friend";
        }
    }
}
