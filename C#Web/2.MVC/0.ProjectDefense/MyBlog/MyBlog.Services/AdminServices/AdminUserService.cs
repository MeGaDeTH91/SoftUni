namespace MyBlog.Services.AdminServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Users;
    using MyBlog.Data;
    using MyBlog.Models.Users;
    using MyBlog.Services.AdminServices.Interfaces;

    public class AdminUserService : BaseBlogService, IAdminUserService
    {
        private readonly UserManager<User> userManager;

        public AdminUserService(BlogDataDbContext context, IMapper mapper, UserManager<User> userManager) : base(context, mapper)
        {
            this.userManager = userManager;
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

        public async Task<string> AddPremiumUserRole(string userId)
        {
            var user = this.DbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);

            if(user == null)
            {
                return ErrorUserId;
            }

            await this.userManager.AddToRoleAsync(user, CommonConstants.PremiumUserSuffix);

            await this.DbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<string> RemovePremiumUserRole(string userId)
        {
            var user = this.DbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                return ErrorUserId;
            }

            await this.userManager.RemoveFromRoleAsync(user, CommonConstants.PremiumUserSuffix);

            await this.DbContext.SaveChangesAsync();

            return user.Id;

        }

        public string BanUser(string userId)
        {
            var user = this.DbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                return ErrorUserId;
            }

            var currentTime = DateTime.UtcNow;

            user.LockoutEnd = currentTime.AddMonths(CommonConstants.AccountLockOutInMonths);

            user.IsBanned = true;

            this.DbContext.SaveChanges();

            return user.Id;
        }

        public string UnbanUser(string userId)
        {
            var user = this.DbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                return ErrorUserId;
            }

            var currentTime = DateTime.UtcNow;

            user.LockoutEnd = currentTime.AddDays(CommonConstants.AccountUnLockOutInDays);

            user.IsBanned = false;
            this.DbContext.SaveChanges();

            return user.Id;
        }
    }
}
