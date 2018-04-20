namespace Forum.App.Menus
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Models;

    public class AddReplyMenu : Menu, ITextAreaMenu, IIdHoldingMenu
    {
        private const int AuthorOffset = 8;
        private const int LeftOffset = 18;
        private const int TopOffset = 7;
        private const int ButtonOffset = 14;

        private ILabelFactory labelFactory;
        private ITextAreaFactory textAreaFactory;
        private IForumReader reader;
        private ICommandFactory commandFactory;
        private IPostService postService;

        private int postId;
        private bool error;
        private IPostViewModel post;
        private string errorMessage;

        public AddReplyMenu(ILabelFactory labelFactory, ITextAreaFactory textAreaFactory, IForumReader reader, ICommandFactory commandFactory, IPostService postService)
        {
            this.labelFactory = labelFactory;
            this.textAreaFactory = textAreaFactory;
            this.reader = reader;
            this.commandFactory = commandFactory;
            this.postService = postService;
        }

        public ITextInputArea TextArea { get; private set; }

        public override IMenu ExecuteCommand()
        {
            if (this.CurrentOption.IsField)
            {
                string fieldInput = " " + this.reader.ReadLine(this.CurrentOption.Position.Left + 1, this.CurrentOption.Position.Top);

                this.Buttons[this.currentIndex] = this.labelFactory.CreateButton(fieldInput, this.CurrentOption.Position, this.CurrentOption.IsHidden, this.CurrentOption.IsField);

                return this;
            }

            try
            {
                string commandName = string.Join(string.Empty, this.CurrentOption.Text.Split());
                ICommand command = this.commandFactory.CreateCommand(commandName);
                IMenu view = command.Execute(this.TextArea.Text, this.postId.ToString());

                return view;
            }
            catch (Exception e)
            {
                this.error = true;
                this.errorMessage = e.Message;
                this.InitializeStaticLabels(Position.ConsoleCenter());
                return this;
            }
        }

        public void SetId(int id)
        {
            this.postId = id;
            this.LoadPost();
        }

        protected override void InitializeStaticLabels(Position consoleCenter)
        {
            Position errorPosition =
                new Position(consoleCenter.Left - (this.post.Title.Length / 2), consoleCenter.Top - 12);
            Position titlePosition =
                new Position(consoleCenter.Left - (this.post.Title.Length / 2), consoleCenter.Top - 10);
            Position authorPosition =
                new Position(consoleCenter.Left - this.post.Author.Length, consoleCenter.Top - 9);

            var labels = new List<ILabel>()
            {
                this.labelFactory.CreateLabel("Cannot add an empty reply!", errorPosition, !this.error),
                this.labelFactory.CreateLabel(this.post.Title, titlePosition),
                this.labelFactory.CreateLabel($"Author: {this.post.Author}", authorPosition),
            };

            int leftPosition = consoleCenter.Left - LeftOffset;

            int lineCount = this.post.Content.Length;

            // Add post contents
            for (int i = 0; i < lineCount; i++)
            {
                Position position = new Position(leftPosition, consoleCenter.Top - (TopOffset - i));
                ILabel label = this.labelFactory.CreateLabel(this.post.Content[i], position);
                labels.Add(label);
            }

            this.Labels = labels.ToArray();
        }

        protected override void InitializeButtons(Position consoleCenter)
        {
            int left = consoleCenter.Left + ButtonOffset;
            int top = consoleCenter.Top - (TopOffset - this.post.Content.Length);

            this.Buttons = new IButton[3];

            this.Buttons[0] = this.labelFactory.CreateButton("Write", new Position(left, top + 1));
            this.Buttons[1] = this.labelFactory.CreateButton("Submit Reply", new Position(left - 1, top + 11));
            this.Buttons[2] = this.labelFactory.CreateButton("Back", new Position(left + 1, top + 12));
        }

        private void InitializeTextArea()
        {
            Position consoleCenter = Position.ConsoleCenter();

            int top = consoleCenter.Top - (TopOffset + this.post.Content.Length) + 5;

            this.TextArea = this.textAreaFactory.CreateTextArea(this.reader, consoleCenter.Left - 18, top, false);
        }

        private void LoadPost()
        {
            this.post = this.postService.GetPostViewModel(this.postId);

            this.InitializeTextArea();
            this.Open();
        }
    }
}
