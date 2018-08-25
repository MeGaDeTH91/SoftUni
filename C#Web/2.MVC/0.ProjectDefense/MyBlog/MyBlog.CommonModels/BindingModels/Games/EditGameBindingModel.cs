namespace MyBlog.CommonModels.BindingModels.Games
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class EditGameBindingModel
    {
        [Required]
        public int Id { get; set; }
                
        [Required(ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [DataType(DataType.ImageUrl, ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        public string PhotoURL { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        public string HighLightVideoURL { get; set; }

        [Required]
        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        public string AdditionalInfoURL { get; set; }

        [Required]
        [MinLength(ValidationConstants.GameConstraints.DescriptionMinLength)]
        public string Description { get; set; }
    }
}
