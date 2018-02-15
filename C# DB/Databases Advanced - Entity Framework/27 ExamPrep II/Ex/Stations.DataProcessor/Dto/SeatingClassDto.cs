namespace Stations.DataProcessor.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class SeatingClassDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Abbreviation { get; set; }
    }
}
