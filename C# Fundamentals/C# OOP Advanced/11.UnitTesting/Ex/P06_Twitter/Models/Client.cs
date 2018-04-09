namespace P06_Twitter.Models
{
    using P06_Twitter.Contracts;
    using System;

    public class Client : IClient
    {
        private IServer server;
        private string testIfCorrectMessageIsWrittenOnConsole;
        private int CountOfInvokedMethods;

        public string ClientName => "MicrowaveOven";

        public Client(IServer server)
        {
            this.server = server;
            this.CountOfInvokedMethods = 0;
        }

        public void ReceiveTweet(ITweet tweet)
        {
            string messageFromTweet = tweet.RetrieveMessage();
            WriteToConsole(messageFromTweet);
            SendToServer(messageFromTweet);
        }

        public void WriteToConsole(string message)
        {
            testIfCorrectMessageIsWrittenOnConsole = message;
            Console.WriteLine(message);
            this.CountOfInvokedMethods++;
        }

        public void SendToServer(string message)
        {
            this.server.SaveInServerDatabase(message);
            this.CountOfInvokedMethods++;
        }        
    }
}
