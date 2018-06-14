namespace GameStore.Models
{
    using GameStore.GameStoreApplication.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class User
    {
        public User()
        {
            this.Games = new HashSet<UserGame>();
            this.ShoppingCart = new HashSet<ShoppingCart>();
            this.IsAdmin = false;
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.AccountConstraints.EmailMinLength)]
        [MaxLength(ValidationConstants.AccountConstraints.EmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MinLength(ValidationConstants.AccountConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.AccountConstraints.NameMaxLength)]
        public string FullName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public ICollection<UserGame> Games { get; set; }

        public bool IsAdmin { get; set; }
        
        public ICollection<ShoppingCart> ShoppingCart { get; set; }
    }
}
