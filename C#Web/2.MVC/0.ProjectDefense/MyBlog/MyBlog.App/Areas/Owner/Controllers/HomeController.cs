namespace MyBlog.App.Areas.Owner.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.Models.Users;
    using MyBlog.Services.OwnerServices.Interfaces;
    using System.Threading.Tasks;

    public class HomeController : BaseOwnerController
    {
        private readonly IOwnerUserService ownerUserService;
        private readonly UserManager<User> userManager;

        public HomeController(IOwnerUserService ownerUserService, UserManager<User> userManager)
        {
            this.ownerUserService = ownerUserService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult OwnerIndex()
        {
            var currentUserId = this.userManager.GetUserAsync(this.User).Result.Id;

            var users = this.ownerUserService.GetAllUsers(currentUserId);

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> MakeAdmin(string id)
        {
            string resultId = await this.ownerUserService.AddAdminUserRole(id);

            if (resultId == CommonConstants.ErrorUserId)
            {
                SetErrorMessage(CommonConstants.NotFoundMessage);

                return this.OwnerIndex();
            }

            return Redirect(string.Format(RedirectConstants.OwnerAreaUserDetailsPage, resultId));
        }

        [HttpGet]
        public async Task<IActionResult> RemoveAdmin(string id)
        {
            string resultId = await this.ownerUserService.RemoveAdminUserRole(id);

            if (resultId == CommonConstants.ErrorUserId)
            {
                SetErrorMessage(CommonConstants.NotFoundMessage);

                return this.OwnerIndex();
            }

            return Redirect(string.Format(RedirectConstants.OwnerAreaUserDetailsPage, resultId));
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