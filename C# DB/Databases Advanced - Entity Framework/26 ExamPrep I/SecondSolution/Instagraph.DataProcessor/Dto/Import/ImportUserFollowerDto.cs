namespace Instagraph.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;

    public class ImportUserFollowerDto
    {
        [Required]
        public string User { get; set; }

        [Required]
        public string Follower { get; set; }
    }
}
