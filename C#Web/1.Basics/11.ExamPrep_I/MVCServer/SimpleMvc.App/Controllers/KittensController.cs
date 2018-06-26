namespace SimpleMvc.App.Controllers
{
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.App.Attributes;
    using SimpleMvc.App.BindingModels;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;
    using SimpleMvc.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class KittensController : BaseController
    {
        private const string InvalidBreedMessage = "Please enter valid breed.";
        private const string InvalidAgeMessage = "Please enter valid age.";
        private const string InvalidInputMessage = "Please enter valid name, age and breed.";
        private const string KittensListKey = "kittensList";

        [HttpGet]
        [PreAuthorize]
        public IActionResult Add()
        {
            if (this.User.IsAuthenticated)
            {
                this.Model.Data[ErrorKey] = HideMessageValue;
                return View();
            }
            this.Model.Data[ErrorKey] = ShowMessageValue;
            this.Model.Data[ErrorKey] = UnauthorizedErrorMessage;

            return RedirectToHome();
        }

        [HttpPost]
        public IActionResult Add(RegisterKittenBindingModel model)
        {
            using (this.Context)
            {
                var breeds = this.Context.Breeds.ToList();

                bool validCatModel = ValidateCatModel(model, breeds);
                if (this.User.IsAuthenticated && validCatModel)
                {
                    Breed breed = this.Context.Breeds.FirstOrDefault(x => x.Name == model.Breed);

                    Kitten kitten = new Kitten()
                    {
                        Name = model.Name,
                        Age = int.Parse(model.Age),
                        BreedId = breed.Id,
                        Breed = breed
                    };

                    breed.Kittens.Add(kitten);

                    this.Context.Kittens.Add(kitten);
                    this.Context.SaveChanges();
                    return this.Add();
                }
                else if (!validCatModel)
                {
                    return View();
                }
            }
            this.Model.Data[ErrorKey] = ShowMessageValue;
            this.Model.Data[ErrorKey] = UnauthorizedErrorMessage;

            return RedirectToAction(LoginRoute);
        }

        [HttpGet]
        [PreAuthorize]
        public IActionResult All()
        {
            StringBuilder result = new StringBuilder();
            result.Append(@"<div class=""row text-center"">");

            if (this.User.IsAuthenticated)
            {
                this.Model.Data[ErrorKey] = HideMessageValue;

                List<Kitten> kittens;

                using (this.Context)
                {
                    kittens = this.Context.Kittens.Include(x => x.Breed).ToList();
                }

                foreach (var kitten in kittens)
                {
                    result.AppendLine(@"<div class=""col-4"">");
                    result.AppendLine(@"<img class=""img-thumbnail""");

                    result.AppendLine($@"<img class=""img-thumbnail"" src=""https://images.pexels.com/photos/20787/pexels-photo.jpg?auto=compress&cs=tinysrgb&h=350"" alt=""{kitten.Breed.Name}'s photo"" height=""300"" width=""300"" />
                    ");

                    //TODO -> Import pictures from jpg folder
                    //                    result.AppendLine($@"<img class=""img-thumbnail"" src=""{kitten.Breed.ImageUrl}"" alt=""{kitten.Breed.Name}'s photo"" height=""300"" width=""300"" />
                    //");
                    result.AppendLine("<div>");
                    result.AppendLine($@"<h5>Name: {kitten.Name}</h5>");
                    result.AppendLine($@"<h5>Age: {kitten.Age}</h5>");
                    result.AppendLine($@"<h5>Breed: {kitten.Breed.Name}</h5>");
                    result.AppendLine("</div>");
                    result.AppendLine("</div>");
                }
                result.AppendLine("</div>");

                this.Model.Data[KittensListKey] = result.ToString();
                
                return View();
            }
            this.Model.Data[ErrorKey] = ShowMessageValue;
            this.Model.Data[ErrorKey] = UnauthorizedErrorMessage;

            return RedirectToHome();
        }
        
        private bool ValidateCatModel(RegisterKittenBindingModel model, List<Breed> breeds)
        {
            bool validName = this.IsValidModel(model);
            if (!validName)
            {
                this.Model.Data[ErrorKey] = ShowMessageValue;
                this.Model.Data[ErrorMessageKey] = InvalidInputMessage;

                return false;
            }

            bool validInteger = int.TryParse(model.Age, out int age);

            if (!breeds.Any(x => x.Name == model.Breed))
            {
                this.Model.Data[ErrorKey] = ShowMessageValue;
                this.Model.Data[ErrorMessageKey] = InvalidBreedMessage;

                return false;
            }
            else if(!validInteger || age < 1)
            {
                this.Model.Data[ErrorKey] = ShowMessageValue;
                this.Model.Data[ErrorMessageKey] = InvalidAgeMessage;

                return false;
            }

            return true;
        }
    }
}
