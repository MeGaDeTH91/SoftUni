namespace SimpleMvc.Domain
{
    using SimpleMvc.Domain.Common;
    using System.Collections.Generic;
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
        [MaxLength(ValidationConstants.UserConstraints.PasswordMaxLength)]
        public string Password { get; set; }

        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
