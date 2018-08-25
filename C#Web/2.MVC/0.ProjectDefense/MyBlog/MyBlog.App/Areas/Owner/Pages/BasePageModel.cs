namespace MyBlog.App.Areas.Owner.Pages
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;

    [Area(CommonConstants.OwnerSuffix)]
    [Authorize(Roles = CommonConstants.OwnerSuffix)]
    public class BasePageModel : PageModel
    {
        protected void SetErrorMessage(string errorMessage)
        {
            this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
            {
                Type = MessageType.Danger,
                Message = errorMessage
            });
        }
    }

}
