﻿namespace SimpleMvc.App.BindingModels
{
    using SimpleMvc.Common;
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserBindingModel
    {
        private const string PasswordLabel = "Password";

        [Required]
        [MinLength(ValidationConstants.UserConstraints.UsernameMinLength)]
        [MaxLength(ValidationConstants.UserConstraints.UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [MinLength(ValidationConstants.UserConstraints.PasswordMinLength)]
        [MaxLength(ValidationConstants.UserConstraints.PasswordMaxLength)]
        public string Password { get; set; }

        [Required]
        [Compare(PasswordLabel)]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [MinLength(ValidationConstants.UserConstraints.EmailMinLength)]
        [MaxLength(ValidationConstants.UserConstraints.EmailMaxLength)]
        public string Email { get; set; }
    }
}
