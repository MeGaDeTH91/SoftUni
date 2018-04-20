namespace Forum.App.Contracts.ViewModels
{
    using System;

    public class PostInfoViewModel : IPostInfoViewModel
    {
        public PostInfoViewModel(int id, string title, int replyCount)
        {
            this.Id = id;
            this.Title = title;
            this.ReplyCount = replyCount;
        }

        public int Id { get; }

        public string Title { get; }

        public int ReplyCount { get; }
    }
}
