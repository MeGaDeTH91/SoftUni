namespace SimpleMvc.App.BindingModels
{
    using SimpleMvc.Domain.Common;
    using System.ComponentModel.DataAnnotations;

    public class AddNoteBindingModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [MinLength(ValidationConstants.NoteConstraints.TitleMinLength)]
        [MaxLength(ValidationConstants.NoteConstraints.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ValidationConstants.NoteConstraints.ContentMinLength)]
        public string Content { get; set; }
    }
}
