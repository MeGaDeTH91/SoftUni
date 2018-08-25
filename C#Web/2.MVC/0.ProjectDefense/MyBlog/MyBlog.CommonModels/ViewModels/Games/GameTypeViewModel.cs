namespace MyBlog.CommonModels.ViewModels.Games
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Common;

    public class GameTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = CommonConstants.GameTypeDisplay)]
        public string GameTypeName { get; set; }

        public ICollection<GameConciseViewModel> Games { get; set; }
    }
}
