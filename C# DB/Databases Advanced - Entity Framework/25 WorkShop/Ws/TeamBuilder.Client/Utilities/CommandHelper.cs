namespace TeamBuilder.Client.Utilities
{
    using System;
    using System.Linq;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public static class CommandHelper
    {
        public static bool IsTeamExisting(string teamName)
        {
            using(TeamBuilderContext db = new TeamBuilderContext())
            {
                return db.Teams.Any(x => x.Name == teamName);
            }
        }

        public static bool IsUserExisting(string username)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                if(db.Users.Any(x => x.Username == username && x.IsDeleted == true))
                {
                    throw new InvalidOperationException($"There is deleted user with username {username}.");
                }
                return db.Users.Any(x => x.Username == username && x.IsDeleted == false);
            }
        }

        public static bool IsInviteExisting(string teamName, User user)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                return db.Invitations
                    .Any(x => x.Team.Name == teamName && x.InvitedUserId == user.UserId && x.IsActive);
            }
        }

        public static bool IsUserCreatorOfTeam(string teamName, User user)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                return db.Teams.Any(t => t.Name == teamName && t.CreatorId == user.UserId);
            }
        }

        public static bool IsUserCreatorOfEvent(string eventName, User user)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                return db.Events.Any(x => x.Name == eventName && x.CreatorId == user.UserId);
            }
        }

        public static bool IsMemberOfTeam(string teamName, string username)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                return db.Teams
                    .Single(t => t.Name == teamName)
                    .UserTeams.Any(x => x.User.Username == username);
            }
        }

        public static bool IsEventExisting(string eventName)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                return db.Events.Any(x => x.Name == eventName);
            }
        }
    }
}
