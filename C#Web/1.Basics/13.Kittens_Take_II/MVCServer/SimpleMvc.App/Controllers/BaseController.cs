namespace SimpleMvc.App.Controllers
{
    using SimpleMvc.Data;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;
    using SimpleMvc.Models;
    using System;
    using System.Linq;
    using System.Text;

    public class BaseController : Controller
    {
        protected const string NavbarKey = "navbar";
        protected const string ErrorKey = "error";
        protected const string IndexContentKey = "indexContent";
        private const string HomeRoute = "/home/index";
        private const string LoginRoute = "/users/login";

        private const string BreedStreetTranscended = "Street Transcended";
        private const string BreedAmericanShortHair = "American Shorthair";
        private const string BreedMunchkin = "Munchkin";
        private const string BreedSiamese = "Siamese";

        private const string ImageUrlStreetTranscended = "../../Content/img/street-transcended.jpg";
        private const string ImageUrlAmericanShortHair = "../../Content/img/american-shorthair.jpg";
        private const string ImageUrlMunchkin = "../../Content/img/munchkin.jpg";
        private const string ImageUrlSiamese = "../../Content/img/siamese.jpg";

        public BaseController()
        {
            this.Context = new KittenDbContext();

            //TODO
            //Comment this if you already have the 4 breed types in database
            this.AddInitialBreedsToDatabase();
        }
        
        protected KittenDbContext Context { get; set; }

        protected IActionResult RedirectToHome => this.RedirectToAction(HomeRoute);
        protected IActionResult RedirectToLogin => this.RedirectToAction(LoginRoute);

        public override void InitializeAuthentication()
        {
            StringBuilder result = new StringBuilder();

            if (this.SessionUser.IsAuthenticated)
            {
                result.AppendLine(@"<li class=""nav-item active"">
                    <a class=""nav-link"" href=""/home/index"">Home</a>
                </li>");
                result.AppendLine(@"<li class=""nav-item active"">
                    <a class=""nav-link"" href=""/kittens/all"">All Kittens</a>
                </li>");
                result.AppendLine(@"<li class=""nav-item active"">
                    <a class=""nav-link"" href=""/kittens/add"">Add Kitten</a>
                </li>");
                result.AppendLine(@"<li class=""nav-item active"">
                    <a class=""nav-link"" href=""/users/logout"">Logout</a>
                </li>");
            }
            else
            {
                result.AppendLine(@"<li class=""nav-item active col-md-4"">
                    <a class=""nav-link"" href=""/home/index"">Home</a>
                </li>");
                result.AppendLine(@"<li class=""nav-item active col-md-4"">
                    <a class=""nav-link"" href=""/users/login"">Login</a>
                </li>");
                result.AppendLine(@"<li class=""nav-item active col-md-4"">
                    <a class=""nav-link"" href=""/users/register"">Register</a>
                </li>");
            }

            this.Model.Data[NavbarKey] = result.ToString();
        }

        private void AddInitialBreedsToDatabase()
        {
            int breedCount = this.Context.Breeds.Count();

            if (breedCount != 4)
            {
                Breed[] initialBreeds = new Breed[]
                {
                    new Breed()
                    {
                        Name = BreedStreetTranscended,
                        ImageUrl = ImageUrlStreetTranscended
                    },
                    new Breed()
                    {
                        Name = BreedAmericanShortHair,
                        ImageUrl = ImageUrlAmericanShortHair
                    },
                    new Breed()
                    {
                        Name = BreedMunchkin,
                        ImageUrl = ImageUrlMunchkin
                    },
                    new Breed()
                    {
                        Name = BreedSiamese,
                        ImageUrl = ImageUrlSiamese
                    }
                };

                this.Context.AddRange(initialBreeds);
                this.Context.SaveChanges();
            }
        }
    }
}
