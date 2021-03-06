﻿namespace SimpleMvc.App.Views.Users
{
    using SimpleMvc.App.ViewModels;
    using SimpleMvc.Framework.Interfaces.Generic;
    using System.Collections.Generic;
    using System.Text;

    public class All : IRenderable<IEnumerable<UserViewModel>>
    {
        public IEnumerable<UserViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"<a href=\"/home/index\">< Home</a>");
            sb.AppendLine("<h3>All users</h3>");
            sb.AppendLine("<ul>");
            foreach (var user in Model)
            {
                sb.AppendLine($"<li><a href=\"/users/profile?id={user.Id}\">{user.Username}</a></li>");
            }
            sb.AppendLine("</ul>");

            return sb.ToString();
        }
    }
}
