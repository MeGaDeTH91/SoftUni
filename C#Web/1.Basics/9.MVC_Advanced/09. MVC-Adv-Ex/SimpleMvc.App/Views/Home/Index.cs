namespace SimpleMvc.App.Views.Home
{
    using SimpleMvc.Framework.Interfaces;
    using System.Text;

    public class Index : IRenderable
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<h3>NotesApp</h3><br/>");

            sb.AppendLine($"<a href=\"/users/all\">All Users</a> ");
            sb.AppendLine($"<a href=\"/users/register\">Register Users</a>");
            return sb.ToString();
        }
    }
}
