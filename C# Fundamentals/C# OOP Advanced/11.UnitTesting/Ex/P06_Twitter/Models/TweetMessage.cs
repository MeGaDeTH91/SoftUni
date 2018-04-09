namespace P06_Twitter.Models
{
    public class TweetMessage : ITweet
    {
        private string message;

        public TweetMessage(string message)
        {
            this.message = message;
        }

        public string RetrieveMessage()
        {
            return this.message;
        }
    }
}
