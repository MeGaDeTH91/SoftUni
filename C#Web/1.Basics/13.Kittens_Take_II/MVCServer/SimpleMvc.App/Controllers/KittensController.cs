namespace SimpleMvc.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.App.BindingModels;
    using SimpleMvc.Common;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Attributes.Security;
    using SimpleMvc.Framework.Interfaces;
    using SimpleMvc.Models;

    public class KittensController : BaseController
    {
        private const string InvalidKittenRegisterInput = "Please fill all kitten register fields correctly.";
        private const string InvalidKittenAge = "Kitten age must be between 0 and 40.";
        private const string InvalidKittenBreed = "Invalid kitten breed.";
        private const string AllCatsKey = "allCats";

        [HttpGet]
        [PreAuthorize]
        public IActionResult Add()
        {
            this.Model.Data[ErrorKey] = string.Empty;

            return this.View();
        }

        [HttpPost]
        public IActionResult Add(RegisterKittenBindingModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.Model.Data[ErrorKey] = InvalidKittenRegisterInput;
            }

            using (this.Context)
            {
                bool isValidAge = int.TryParse(model.Age, out int age) && (age >= ValidationConstants.KittenConstraints.MinAge && age <= ValidationConstants.KittenConstraints.MaxAge);
                bool isValidBreed = ValidationConstants.BreedConstraints.AllowedBreeds.Contains(model.Breed);

                if (!isValidAge)
                {
                    this.Model.Data[ErrorKey] = InvalidKittenAge;
                }
                else if (!isValidBreed)
                {
                    this.Model.Data[ErrorKey] = InvalidKittenBreed;
                }
                else
                {
                    Breed breed = this.Context.Breeds.FirstOrDefault(x => x.Name == model.Breed);

                    Kitten kitten = new Kitten()
                    {
                        Name = model.Name,
                        Age = age,
                        BreedId = breed.Id,
                        Breed = breed
                    };

                    this.Context.Kittens.Add(kitten);
                    this.Context.SaveChanges();

                    return RedirectToHome;
                }
            }

            return this.View();
        }

        [HttpGet]
        [PreAuthorize]
        public IActionResult All()
        {
            StringBuilder result = new StringBuilder();
            result.Append(@"<div class=""row text-center"">");

            using (this.Context)
            {
                var kittens = this.Context.Kittens.Include(x => x.Breed).ToList();
                
                int catsOnRow = 1;

                foreach (var kitten in kittens)
                {
                    result.AppendLine(@"<div class=""col-4"">");

                    result.AppendLine($@"<img class=""img-thumbnail"" src=""{kitten.Breed.ImageUrl}"" alt=""{kitten.Breed.Name}'s photo"" height=""300"" width=""300"" />
                        ");

                    result.AppendLine("<div>");
                    result.AppendLine($@"<h5>Name: {kitten.Name}</h5>");
                    result.AppendLine($@"<h5>Age: {kitten.Age}</h5>");
                    result.AppendLine($@"<h5>Breed: {kitten.Breed.Name}</h5>");
                    result.AppendLine("</div>");
                    result.AppendLine("</div>");

                    if (catsOnRow == 3)
                    {
                        result.AppendLine(@"</div><div class=""row text-center"">");
                        catsOnRow = 0;
                    }

                    catsOnRow++;
                }

                result.AppendLine("</div>");
            }

            this.Model.Data[AllCatsKey] = result.ToString();

            return this.View();
        }
    }
}
