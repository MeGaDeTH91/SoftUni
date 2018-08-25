namespace MyBlog.Models.Music.Instruments
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class InstrumentType
    {
        public InstrumentType()
        {
            this.Instruments = new List<Instrument>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.InstrumentTypeConstraints.NameMinLength)]
        [MaxLength(ValidationConstants.InstrumentTypeConstraints.NameMaxLength)]
        public string TypeName { get; set; }

        public ICollection<Instrument> Instruments { get; set; }
    }
}
