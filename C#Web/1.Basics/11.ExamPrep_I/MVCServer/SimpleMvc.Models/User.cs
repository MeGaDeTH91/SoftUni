namespace SimpleMvc.Models
{
    using SimpleMvc.Common;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.UserConstraints.UsernameMinLength)]
        [MaxLength(ValidationConstants.UserConstraints.UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [MinLength(ValidationConstants.UserConstraints.PasswordMinLength)]
        public string Password { get; set; }

        [Required]
        [MinLength(ValidationConstants.UserConstraints.EmailMinLength)]
        [MaxLength(ValidationConstants.UserConstraints.EmailMaxLength)]
        public string Email { get; set; }
    }
}
