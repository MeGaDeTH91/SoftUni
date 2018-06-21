namespace SimpleMvc.Domain
{
    using SimpleMvc.Domain.Common;
    using System.ComponentModel.DataAnnotations;

    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.NoteConstraints.TitleMinLength)]
        [MaxLength(ValidationConstants.NoteConstraints.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ValidationConstants.NoteConstraints.ContentMinLength)]
        public string Content { get; set; }

        [Required]
        public int OwnerId { get; set; }
        public User Owner { get; set; }
    }
}
