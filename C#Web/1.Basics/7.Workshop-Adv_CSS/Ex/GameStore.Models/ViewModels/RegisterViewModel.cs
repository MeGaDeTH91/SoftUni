namespace GameStore.Models.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [MinLength(3)]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        public string FullName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string ConfirmPasswordHash { get; set; }

        public ICollection<Game> Games { get; set; } = new HashSet<Game>();

        public bool IsAdmin { get; set; }
    }
}
