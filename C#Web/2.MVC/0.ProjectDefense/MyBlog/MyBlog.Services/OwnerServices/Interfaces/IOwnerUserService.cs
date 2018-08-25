namespace MyBlog.Services.OwnerServices.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MyBlog.CommonModels.ViewModels.Users;

    public interface IOwnerUserService
    {
        ICollection<UserConciseViewModel> GetAllUsers(string currentUserId);

        UserDetailsViewModel GetUser(string userId);

        Task<string> AddAdminUserRole(string userId);

        Task<string> RemoveAdminUserRole(string userId);
    }
}
