namespace Stations.DataProcessor.Dto
{
    using Stations.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("Card")]
    public class CardDto
    {
        [Required]
        public string Name { get; set; }

        [Required]        
        public int Age { get; set; }

        public string CardType { get; set; } = "Normal";
    }
}
