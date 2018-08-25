namespace MyBlog.CommonModels.BindingModels.Music.Instruments
{
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class AddInstrumentTypeBindingModel
    {
        [Required]
        [MinLength(ValidationConstants.InstrumentTypeConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.InstrumentTypeConstraints.NameMaxLength)]
        [Display(Name = CommonConstants.InstrumentTypeDisplay)]
        public string TypeName { get; set; }
    }
}
