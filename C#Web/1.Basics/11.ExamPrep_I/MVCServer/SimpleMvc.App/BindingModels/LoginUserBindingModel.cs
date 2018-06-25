namespace SimpleMvc.App.BindingModels
{
    using SimpleMvc.Common;
    using System.ComponentModel.DataAnnotations;

    public class LoginUserBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.UserConstraints.UsernameMinLength)]
        [MaxLength(ValidationConstants.UserConstraints.UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [MinLength(ValidationConstants.UserConstraints.PasswordMinLength)]
        public string Password { get; set; }
    }
}
