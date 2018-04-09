namespace P06_Twitter.Models
{
    using P06_Twitter.Contracts;
    using System;

    public class Domain : IDomain
    {
        private IServer server;
        private IClient client;
        private ITweet tweet;

        

        public Domain()
        {
            this.server = new Server();
            this.client = new Client(this.server);
        }

        public void ProcessMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Invalid message!");
            }

            this.tweet = new TweetMessage(message);

            this.client.ReceiveTweet(this.tweet);
        }
    }
}
