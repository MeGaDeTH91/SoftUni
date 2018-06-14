namespace GameStore.Models.ViewModels
{
    using GameStore.GameStoreApplication.Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AdminAddGameViewModel
    {
        [Required]
        [MinLength(ValidationConstants.GameConstraints.TitleMinLength)]
        [MaxLength(ValidationConstants.GameConstraints.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ValidationConstants.GameConstraints.VideoLength)]
        [MaxLength(ValidationConstants.GameConstraints.VideoLength)]
        public string Trailer { get; set; }

        public double Size { get; set; }

        public decimal Price { get; set; }

        [StringLength(ValidationConstants.GameConstraints.StringMaxLength)]
        public string ImageURL { get; set; }

        [Required]
        [MinLength(ValidationConstants.GameConstraints.DescriptionMinLength)]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
