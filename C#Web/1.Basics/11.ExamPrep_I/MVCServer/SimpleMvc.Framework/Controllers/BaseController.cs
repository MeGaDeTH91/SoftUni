using SimpleMvc.Data;
using SimpleMvc.Framework.Interfaces;
using SimpleMvc.Models;
using System;
using System.Linq;
using System.Text;

namespace SimpleMvc.Framework.Controllers
{
    public class BaseController : Controller
    {
        protected const string NavbarKey = "navbar";
        protected const string HomeRoute = "/home/index";
        protected const string LoginRoute = "/users/login";
        protected const string ErrorKey = "show-error";
        protected const string ErrorMessageKey = "errorMessage";
        protected const string UnauthorizedErrorMessage = "You are not authorized to view this content.";
        protected const string HideMessageValue = "none";
        protected const string ShowMessageValue = "show";
        private const string BreedStreetTranscended = "Street Transcended";
        private const string BreedAmericanShortHair = "American Shorthair";
        private const string BreedMunchkin = "Munchkin";
        private const string BreedSiamese = "Siamese";

        private const string ImageUrlStreetTranscended = "https://previews.123rf.com/images/kozorog/kozorog1612/kozorog161200045/67343076-street-cat-begging-to-the-house-peering-through-a-window-the-cat-meows.jpg";
        private const string ImageUrlAmericanShortHair = "http://cdn3-www.cattime.com/assets/uploads/2011/12/file_2716_American-Shorthair-cat-bree-460x290.jpg";
        private const string ImageUrlMunchkin = "https://static.boredpanda.com/blog/wp-content/uploads/2016/12/Meet-albertbabycat-An-Instagram-famous-munchkin-cat-who-currently-has-almost-450000-followers-5857b1d9ac8da__700.jpg";
        private const string ImageUrlSiamese = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTlUNbUG52ki0PqN4C6dnmifyoMWlzPUrd8YXeWbczb5oN5ppuT";
        
        public BaseController()
        {
            this.Context = new KittenDbContext();
            this.InitializeAuthorization();

            //TODO
            //Uncomment if there is no any breed in database
            //this.AddInitialBreeds();
        }
        
        protected KittenDbContext Context { get; set; }

        protected internal override void InitializeAuthorization()
        {
            StringBuilder result = new StringBuilder();

            //Home Button
            result.AppendLine($@"<li class=""nav-item active""><a class=""nav-link"" href=""/home/index"">Home</a></li>");

            if (this.User.IsAuthenticated)
            {
                result.AppendLine($@"<li class=""nav-item active""><a class=""nav-link"" href=""/kittens/all"">All Kittens</a></li>");

                result.AppendLine($@"<li class=""nav-item active""><a class=""nav-link"" href=""/kittens/add"">Add Kitten</a></li>");

                result.AppendLine($@"<li class=""nav-item active""><a class=""nav-link"" href=""/users/logout"">Logout</a></li>");
                
            }
            else
            {
                result.AppendLine($@"<li class=""nav-item active""><a class=""nav-link"" href=""/users/login"">Login</a></li>");

                result.AppendLine($@"<li class=""nav-item active""><a class=""nav-link"" href=""/users/register"">Register</a></li>");
            }

            this.Model.Data[NavbarKey] = result.ToString();
        }

        protected IActionResult RedirectToHome() => this.RedirectToAction(HomeRoute);

        private void AddInitialBreeds()
        {
            int breedCount = this.Context.Breeds.Count();

            if(breedCount != 4)
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
