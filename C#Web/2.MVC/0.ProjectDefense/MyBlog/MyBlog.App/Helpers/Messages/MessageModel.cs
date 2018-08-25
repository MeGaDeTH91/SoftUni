namespace MyBlog.App.Helpers.Messages
{
    using System;

    [Serializable]
    public class MessageModel
    {
        public MessageType Type { get; set; }

        public string Message { get; set; }
    }
}
