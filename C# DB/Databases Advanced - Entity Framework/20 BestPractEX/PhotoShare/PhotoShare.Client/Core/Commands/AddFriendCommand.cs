namespace PhotoShare.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class AddFriendCommand
    {
        // AddFriend <username1> <username2>
        public static string Execute(string[] data)
        {
            string senderName = data[1];
            string receiverName = data[2];

            using(var context = new PhotoShareContext())
            {
                var sender = context.Users
                    .Include(x => x.FriendsAdded)
                    .Include(x => x.AddedAsFriendBy)
                    .Where(x => x.Username == senderName)
                    .FirstOrDefault();

                var receiver = context.Users
                    .Include(x => x.FriendsAdded)
                    .Include(x => x.AddedAsFriendBy)
                    .Where(x => x.Username == receiverName)
                    .FirstOrDefault();

                if(sender == null)
                {
                    throw new ArgumentException($"{senderName} not found!");
                }
                if (receiver == null)
                {
                    throw new ArgumentException($"{receiverName} not found!");
                }
                if (sender == receiver)
                {
                    throw new ArgumentException("Usernames must be different!");
                }
                if (Session.User == null || sender.Username != Session.User.Username)
                {
                    throw new InvalidOperationException($"Invalid credentials!");
                }

                bool alreadySent = sender.FriendsAdded.Any(x => x.Friend == receiver);
                bool alreadyAccepted = sender.AddedAsFriendBy.Any(x => x.Friend == sender);
                bool alreadyHaveRequest = sender.AddedAsFriendBy.Any(x => x.User == receiver && x.Friend == sender);

                if (alreadySent && !alreadyAccepted)
                {
                    throw new ArgumentException($"Friend request already sent!");
                }

                if (alreadySent && alreadyAccepted)
                {
                    throw new ArgumentException($"{receiverName} is already a friend to {senderName}");
                }

                if (alreadyHaveRequest)
                {
                    throw new ArgumentException($"{senderName} has already received a friend request from {receiverName}");
                }

                Friendship friendAdded = new Friendship()
                {
                    User = sender,
                    Friend = receiver
                };

                sender.FriendsAdded.Add(friendAdded);
                context.SaveChanges();
            }

            return $"Friend {receiverName} added to {senderName}";
        }
    }
}
