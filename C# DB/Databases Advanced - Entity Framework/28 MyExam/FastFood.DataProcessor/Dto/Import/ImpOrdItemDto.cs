namespace FastFood.DataProcessor.Dto.Import
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Item")]
    public class ImpOrdItemDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [Range(typeof(int), "1", "2147483646")]
        [XmlElement("Quantity")]
        public int Quantity { get; set; }
    }
}
