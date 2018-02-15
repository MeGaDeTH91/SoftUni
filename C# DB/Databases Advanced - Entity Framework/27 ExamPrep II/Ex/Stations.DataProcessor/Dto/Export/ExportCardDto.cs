namespace Stations.DataProcessor.Dto.Export
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("Card")]
    public class ExportCardDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        public ExportTicketDto[] Tickets { get; set; }
    }
}
