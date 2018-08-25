namespace MyBlog.Models.Music.Instruments
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;
    using MyBlog.Models.Users;
    using MyBlog.Models.Brands;

    public class Instrument
    {
        public Instrument()
        {
            this.AddedToFavoritesBy = new List<UserInstruments>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        [Required]
        [MinLength(ValidationConstants.InstrumentConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.InstrumentConstraints.NameMaxLength)]
        public string ModelName { get; set; }

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
        [MinLength(ValidationConstants.InstrumentConstraints.DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public int InstrumentTypeId { get; set; }

        public InstrumentType InstrumentType { get; set; }
        
        public ICollection<UserInstruments> AddedToFavoritesBy { get; set; }
    }
}
