namespace SoftUni.WebServer.App.BindingModels
{
    using SimpleMvc.Common;
    using System.ComponentModel.DataAnnotations;

    public class CreateProductBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.ProductConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.ProductConstraints.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Price { get; set; }

        public string Description { get; set; }

        [Required]
        public string ProductType { get; set; }
    }
}
