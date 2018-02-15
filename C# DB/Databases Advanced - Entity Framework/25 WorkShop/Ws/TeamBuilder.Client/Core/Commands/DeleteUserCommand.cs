using Microsoft.EntityFrameworkCore;
using TeamBuilder.Client.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.Client.Core.Commands
{
    public class DeleteUserCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(0, inputArgs);

            AuthenticationManager.Authorize();

            User currentUser = AuthenticationManager.GetCurrentUser();

            using(var db = new TeamBuilderContext())
            {
                db.Entry(currentUser).State = EntityState.Unchanged;

                currentUser.IsDeleted = true;
                db.SaveChanges();

                AuthenticationManager.Logout();
            }
            return $"User {currentUser.Username} was deleted successfully!";
        }
    }
}
