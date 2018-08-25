namespace MyBlog.CommonModels.ViewModels.Music.Artists
{
    using System.Collections.Generic;

    public class ArtistTypeViewModel
    {
        public int Id { get; set; }

        public string ArtistTypeName { get; set; }

        public ICollection<ArtistConciseViewModel> Artists { get; set; }
    }
}
