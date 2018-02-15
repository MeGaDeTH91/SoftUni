namespace Stations.DataProcessor.Dto.Ticket
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("Card")]
    public class TicketCardDto
    {
        [Required]
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
}
