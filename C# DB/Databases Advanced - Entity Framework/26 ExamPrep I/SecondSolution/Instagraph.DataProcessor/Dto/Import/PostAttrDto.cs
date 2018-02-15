namespace Instagraph.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("post")]
    public class PostAttrDto
    {
        [Required]
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
