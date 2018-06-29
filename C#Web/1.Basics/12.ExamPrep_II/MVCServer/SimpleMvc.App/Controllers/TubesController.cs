namespace SimpleMvc.App.Controllers
{
    using System.Linq;
    using SimpleMvc.App.BindingModels;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Attributes.Security;
    using SimpleMvc.Framework.Interfaces;
    using SimpleMvc.Models;    

    public class TubesController : BaseController
    {
        private const string InvalidTubeInput = "Please fill in the Upload information fields correctly.";
        private const int YouTubeIdLength = 11;

        private const string TitleKey = "title";
        private const string YouTubeIdKey = "youTubeId";
        private const string AuthorKey = "author";
        private const string ViewsKey = "views";
        private const string DescriptionKey = "description";
        
        [HttpGet]
        [PreAuthorize]
        public IActionResult Upload()
        {
            if (this.SessionUser.IsAuthenticated)
            {
                this.Model.Data[ErrorKey] = string.Empty;
                return View();
            }
            return RedirectToLogin();
        }

        [HttpPost]
        public IActionResult Upload(UploadTubeBindingModel model)
        {
            if (this.SessionUser.IsAuthenticated)
            {
                if (!this.IsValidModel(model))
                {
                    this.Model.Data[ErrorKey] = InvalidTubeInput;

                    return View();
                }
                else
                {
                    string username = this.SessionUser.Name;

                    using (this.Context)
                    {
                        User uploader = this.Context.Users.FirstOrDefault(x => x.Username == username);

                        int linkLength = model.YoutubeLink.Length;

                        string youTubeId = model.YoutubeLink.Substring(linkLength - YouTubeIdLength);

                        Tube tubeToAdd = new Tube()
                        {
                            Title = model.Title,
                            Author = model.Author,
                            YouTubeId = youTubeId,
                            UploaderId = uploader.Id,
                            Uploader = uploader,
                            Description = model.Description
                        };

                        this.Context.Tubes.Add(tubeToAdd);
                        this.Context.SaveChanges();
                    }
                }
                return RedirectToHome();
            }
            return RedirectToLogin();
        }

        [HttpGet]
        [PreAuthorize]
        public IActionResult Details(int id)
        {
            if (!this.SessionUser.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            Tube tube = default(Tube);

            using (this.Context)
            {
                tube = this.Context.Tubes.FirstOrDefault(x => x.Id == id);

                if(tube == default(Tube))
                {
                    return RedirectToHome();
                }

                tube.Views++;
                this.Context.SaveChanges();
            }

            string tubeViewSuffix = tube.Views != 1 ? "Views" : "View";

            this.Model.Data[TitleKey] = tube.Title;
            this.Model.Data[YouTubeIdKey] = tube.YouTubeId;
            this.Model.Data[AuthorKey] = tube.Author;
            this.Model.Data[ViewsKey] = $"{tube.Views.ToString()} {tubeViewSuffix}";
            this.Model.Data[DescriptionKey] = tube.Description;

            return this.View();
        }
    }
}
