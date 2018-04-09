namespace P06_Twitter.Contracts
{
    public interface IClient
    {
        void ReceiveTweet(ITweet tweet);
        void WriteToConsole(string message);
        void SendToServer(string message);
    }
}
