﻿using Stations.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stations.DataProcessor.Dto
{
    public class TrainDto
    {
        [Required]
        [MaxLength(10)]
        public string TrainNumber { get; set; }

        public string Type { get; set; } = "HighSpeed";

        public SeatDto[] Seats { get; set; } = new SeatDto[0];
    }
}
