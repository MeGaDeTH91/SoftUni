namespace SoftUni.WebServer.Models
{
    using SimpleMvc.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Orders = new List<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.UserConstraints.UsernameMinLength)]
        [MaxLength(ValidationConstants.UserConstraints.UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [MinLength(ValidationConstants.UserConstraints.PasswordMinLength)]
        [MaxLength(ValidationConstants.UserConstraints.PasswordMaxLength)]
        public string Password { get; set; }

        [Required]
        [MinLength(ValidationConstants.UserConstraints.FullNameMinLength)]
        [MaxLength(ValidationConstants.UserConstraints.FullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [MinLength(ValidationConstants.UserConstraints.EmailMinLength)]
        [MaxLength(ValidationConstants.UserConstraints.EmailMaxLength)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
