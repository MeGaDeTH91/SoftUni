namespace SimpleMvc.App.BindingModels
{
    using SimpleMvc.Common;
    using System.ComponentModel.DataAnnotations;

    public class RegisterKittenBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.KittenConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.KittenConstraints.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Age { get; set; }
        
        [Required]
        public string Breed { get; set; }
    }
}
