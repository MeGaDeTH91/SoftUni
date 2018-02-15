namespace Instagraph.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("comment")]
    public class ImpCommentDto
    {
        [Required]
        [MaxLength(250)]
        [XmlElement("content")]
        public string Content { get; set; }

        [Required]
        [MaxLength(30)]
        [XmlElement("user")]
        public string User { get; set; }

        [Required]
        [XmlElement("post")]
        public PostAttrDto Post { get; set; }
    }
}
