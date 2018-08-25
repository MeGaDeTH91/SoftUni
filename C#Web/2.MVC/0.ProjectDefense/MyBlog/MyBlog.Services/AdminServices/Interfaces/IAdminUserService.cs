namespace MyBlog.Services.AdminServices.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MyBlog.CommonModels.ViewModels.Users;

    public interface IAdminUserService
    {
        ICollection<UserConciseViewModel> GetAllUsers(string currentUserId);

        UserDetailsViewModel GetUser(string userId);

        Task<string> AddPremiumUserRole(string userId);

        Task<string> RemovePremiumUserRole(string userId);

        string BanUser(string userId);

        string UnbanUser(string UserId);
    }
}
