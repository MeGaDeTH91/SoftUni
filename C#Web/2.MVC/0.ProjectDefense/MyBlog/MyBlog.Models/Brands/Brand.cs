namespace MyBlog.Models.Brands
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;
    using MyBlog.Models.ProductsForSale;
    using MyBlog.Models.Games;
    using MyBlog.Models.Users;
    using MyBlog.Models.Music.Instruments;

    public class Brand
    {
        public Brand()
        {
            this.Instruments = new List<Instrument>();

            this.Games = new List<Game>();

            this.Products = new List<Product>();

            this.AddedToFavoritesBy = new List<UserBrands>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.BrandConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.BrandConstraints.NameMaxLength)]
        public string BrandName { get; set; }

        [Required]
        [MinLength(ValidationConstants.BrandConstraints.DescriptionMinLength)]
        public string BrandDescription { get; set; }

        [Required(ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        [DataType(DataType.ImageUrl, ErrorMessage = ValidationConstants.ErrorMessages.ImageURLMessage)]
        public string BrandImageURL { get; set; }

        [Required]
        [DataType(DataType.Url, ErrorMessage = ValidationConstants.ErrorMessages.URLMessage)]
        public string AdditionalInfoURL { get; set; }

        [Required]
        public int BrandTypeId { get; set; }
        public BrandType BrandType { get; set; }

        public ICollection<Instrument> Instruments { get; set; }

        public ICollection<Game> Games { get; set; }

        public ICollection<Product> Products { get; set; }
        
        public ICollection<UserBrands> AddedToFavoritesBy { get; set; }
    }
}
