namespace MyBlog.App.Areas.Administrator.Pages.Users
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Users;
    using MyBlog.Services.AdminServices.Interfaces;

    public class UserDetailsModel : BasePageModel
    {
        public UserDetailsViewModel UserDetailsViewModel { get; private set; }
        private readonly IAdminUserService adminUserService;

        public string UserId { get; set; }

        public UserDetailsModel(IAdminUserService adminUserService)
        {
            this.adminUserService = adminUserService;
        }

        public IActionResult OnGet(string id)
        {
            var user = this.adminUserService.GetUser(id);

            if (user == null)
            {
                this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = CommonConstants.NotFoundMessage
                });
            }

            this.UserId = id;

            this.UserDetailsViewModel = user;

            return this.Page();
        }
    }
}