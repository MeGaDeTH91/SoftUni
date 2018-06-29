namespace SimpleMvc.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;
    using SimpleMvc.Models;    

    public class HomeController : BaseController
    {
        private const string IndexContentKey = "indexContent";

        [HttpGet]
        public IActionResult Index()
        {
            StringBuilder result = new StringBuilder();
            
            if (this.SessionUser.IsAuthenticated)
            {
                List<Tube> videos = new List<Tube>();

                using (this.Context)
                {
                    videos = this.Context.Tubes.ToList();
                }

                result.AppendLine(@"<div class=""form-holder text-center"">");

                result.AppendLine($@"<h2 class=""text-info text-center"">Welcome, {this.SessionUser.Name}</h2>
                            <hr class=""my-3"" />");

                result.AppendLine(@"</div>");

                result.Append(@"<div class=""row justify-content-center text-center"">");

                for (int i = 0; i < videos.Count; i++)
                {
                    var video = videos[i];

                    result
                        .AppendLine(@"<div class=""col-3"">")
                        .AppendLine($@"<a href=""/tubes/details?id={video.Id}"">")
                        .AppendLine($@"<img class=""img-thumbnail tube-thumbnail"" src=""https://img.youtube.com/vi/{video.YouTubeId}/0.jpg"" alt=""{video.Title}"" />")
                        .AppendLine(@"</a>")
                        .AppendLine($@"<div>
                                            <h5>{video.Title}</h5>
                                            <h5><i>{video.Author}</i></h5>
                                           </div>");
                    result.AppendLine("</div>");

                    if (i % 3 == 2)
                    {
                        result.Append(@"</div><div class=""row justify-content-center text-center"">");
                    }
                }

                result.AppendLine("</div>");
            }
            else
            {
                result.AppendLine(@"<div class=""jumbotron"">
                        <p class=""h1 display-3"">Welcome to MeTube&trade;!</p>
                        <p class=""h3"">The simplest, easiest to use, most comfortable Multimedia Application.</p>
                        <hr class=""my-3"">
                        <p><a href=""/users/login"">Login</a> if you have an account or <a href=""/users/register"">Register</a> now and start tubing.</p>
                    </div>");
            }

            this.Model.Data[IndexContentKey] = result.ToString();

            return View();
        }
    }
}
