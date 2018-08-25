namespace MyBlog.Services.OwnerServices
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Users;
    using MyBlog.Data;
    using MyBlog.Models.Users;
    using MyBlog.Services.OwnerServices.Interfaces;

    public class OwnerUserService : BaseBlogService, IOwnerUserService
    {
        private readonly UserManager<User> userManager;

        public OwnerUserService(BlogDataDbContext context, IMapper mapper, UserManager<User> userManager) : base(context, mapper)
        {
            this.userManager = userManager;
        }

        public async Task<string> AddAdminUserRole(string userId)
        {
            var user = this.DbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                return ErrorUserId;
            }

            await this.userManager.AddToRoleAsync(user, CommonConstants.AdminSuffix);

            await this.DbContext.SaveChangesAsync();

            return user.Id;
        }

        public ICollection<UserConciseViewModel> GetAllUsers(string currentUserId)
        {
            var users = this.userManager
                .Users
                .Where(x => x.Id != currentUserId)
                .Select(Mapper.Map<UserConciseViewModel>)
                .ToList();

            return users;
        }

        public UserDetailsViewModel GetUser(string userId)
        {
            var user = this.userManager
                .Users
                .FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                return null;
            }

            var roles = this.userManager.GetRolesAsync(user).Result.ToList();

            var userModel = this.Mapper.Map<UserDetailsViewModel>(user);

            userModel.UserRoles = roles;

            return userModel;
        }

        public async Task<string> RemoveAdminUserRole(string userId)
        {
            var user = this.DbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                return ErrorUserId;
            }

            await this.userManager.RemoveFromRoleAsync(user, CommonConstants.AdminSuffix);

            await this.DbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}
