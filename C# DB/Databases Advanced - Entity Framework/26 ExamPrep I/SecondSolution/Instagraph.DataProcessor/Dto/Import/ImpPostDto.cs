namespace Instagraph.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("post")]
    public class ImpPostDto
    {
        [Required]
        [XmlElement("caption")]
        public string Caption { get; set; }

        [Required]
        [XmlElement("user")]
        [MaxLength(30)]
        public string User { get; set; }

        [Required]
        [XmlElement("picture")]
        public string Picture { get; set; }
    }
}
