﻿namespace FastFood.DataProcessor.Dto.Import
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Order")]
    public class ImpOrderDto
    {
        [Required]
        [XmlElement("Customer")]
        public string Customer { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [XmlElement("Employee")]
        public string Employee { get; set; }

        [Required]
        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [Required]
        [XmlElement("Type")]
        public string Type { get; set; }

        [Required]        
        public ImpOrdItemDto[] Items { get; set; }
    }
}
