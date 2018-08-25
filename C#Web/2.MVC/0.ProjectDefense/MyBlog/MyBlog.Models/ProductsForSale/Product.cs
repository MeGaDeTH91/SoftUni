namespace MyBlog.Models.ProductsForSale
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MyBlog.Common;
    using MyBlog.Models.Brands;
    using MyBlog.Models.Users;

    public class Product
    {
        public Product()
        {
            this.BoughtBy = new List<UserProducts>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.ProductConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.ProductConstraints.NameMaxLength)]
        public string ProductName { get; set; }

        [Required]
        [Column(TypeName = CommonConstants.ProductPriceColumnFormat)]
        public decimal Price { get; set; }

        [Required]
        public int BrandId { get; set; }

        public Brand Brand { get; set; }

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
        [MinLength(ValidationConstants.ProductConstraints.DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }

        public ICollection<UserProducts> BoughtBy { get; set; }
    }
}
