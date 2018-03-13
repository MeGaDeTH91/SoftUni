﻿namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.Input;
    using Forum.App.UserInterface.ViewModels;
    using Forum.App.Views;
    using System.Linq;

    public class AddReplyController : IController
    {
        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 6;
        private const int POST_MAX_LENGTH = 220;
        private static int centerTop = Position.ConsoleCenter().Top;
        private static int centerLeft = Position.ConsoleCenter().Left;

        public ReplyViewModel Reply { get; private set; }
        public PostViewModel Post { get; private set; }
        public TextArea TextArea { get; set; }
        public bool Error { get; private set; }

        public AddReplyController()
        {
            this.ResetReply();
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {                
                case Command.Write:
                    this.TextArea.Write();
                    this.Reply.Content = this.TextArea
                                                .Lines.ToList();
                    return MenuState.AddReply;
                case Command.Submit:
                    bool isReplyAdded = PostService.TryAddReply(this.Post.PostId, this.Reply);
                    if (!isReplyAdded)
                    {
                        this.Error = true;
                        return MenuState.Rerender;
                    }
                    return MenuState.ReplyAdded;
                case Command.Back:
                    ForumViewEngine.ResetBuffer();
                    return MenuState.Back;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            this.Post.Author = userName;
            this.Reply.Author = userName;
            return new AddReplyView(this.Post, this.Reply, this.TextArea, this.Error);
        }

        public void ResetReply()
        {
            this.Error = false;
            this.Reply = new ReplyViewModel();
            var postTitleLines = this.Post?.Content.Count + 1 ?? 1;
            this.TextArea = new TextArea(centerLeft - 18, centerTop + postTitleLines - 7, TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);
        }

        public void GetPostViewModel(int postId)
        {
            this.Post = PostService.GetPostViewModel(postId);
            this.ResetReply();
        }

        private enum Command
        {
            Write, Submit, Back
        }
    }
}
