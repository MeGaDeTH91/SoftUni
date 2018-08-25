namespace MyBlog.CommonModels.ViewModels.Music.Songs
{
    using System.Collections.Generic;

    public class SongGenreViewModel
    {
        public int Id { get; set; }
        
        public string GenreName { get; set; }

        public ICollection<SongConciseViewModel> Songs { get; set; }

    }
}
