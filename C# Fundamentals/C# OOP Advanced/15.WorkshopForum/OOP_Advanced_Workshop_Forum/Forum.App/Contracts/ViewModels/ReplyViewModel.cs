namespace Forum.App.Contracts.ViewModels
{
    using System;

    public class ReplyViewModel : ContentViewModel, IReplyViewModel
    {
        public ReplyViewModel(string author, string content) : base(content)
        {
            this.Author = author;
        }

        public string Author { get; }
    }
}
