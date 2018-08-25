namespace MyBlog.App.Areas.Administrator.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.Models.Users;
    using MyBlog.Services.AdminServices.Interfaces;
    using System.Threading.Tasks;

    public class UsersController : AdminController
    {
        private readonly IAdminUserService adminUserService;
        private readonly UserManager<User> userManager;

        public UsersController(IAdminUserService adminUserService, UserManager<User> userManager)
        {
            this.adminUserService = adminUserService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var currentUserId = this.userManager.GetUserAsync(this.User).Result.Id;

            var users = this.adminUserService.GetAllUsers(currentUserId);

            return View(users);
        }
        
        [HttpGet]
        public async Task<IActionResult> MakePremium(string id)
        {
            string resultId = await this.adminUserService.AddPremiumUserRole(id);

            if(resultId == CommonConstants.ErrorUserId)
            {
                SetErrorMessage(CommonConstants.NotFoundMessage);

                return this.Index();
            }

            return Redirect(string.Format(RedirectConstants.AdministratorAreaUserDetailsPage, resultId));
        }

        [HttpGet]
        public async Task<IActionResult> RemovePremium(string id)
        {
            string resultId = await this.adminUserService.RemovePremiumUserRole(id);

            if (resultId == CommonConstants.ErrorUserId)
            {
                SetErrorMessage(CommonConstants.NotFoundMessage);

                return this.Index();
            }

            return Redirect(string.Format(RedirectConstants.AdministratorAreaUserDetailsPage, resultId));
        }

        [HttpGet]
        public IActionResult Ban(string id)
        {
            string resultId = this.adminUserService.BanUser(id);

            if (resultId == CommonConstants.ErrorUserId)
            {
                SetErrorMessage(CommonConstants.NotFoundMessage);

                return this.Index();
            }

            return Redirect(string.Format(RedirectConstants.AdministratorAreaUserDetailsPage, resultId));
        }

        [HttpGet]
        public IActionResult Unban(string id)
        {
            string resultId = this.adminUserService.UnbanUser(id);

            if (resultId == CommonConstants.ErrorUserId)
            {
                SetErrorMessage(CommonConstants.NotFoundMessage);

                return this.Index();
            }

            return Redirect(string.Format(RedirectConstants.AdministratorAreaUserDetailsPage, resultId));
        }

        private void SetErrorMessage(string errorMessage)
        {
            this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
            {
                Type = MessageType.Danger,
                Message = errorMessage
            });
        }
    }
}