namespace P06_Twitter.Models
{
    using System;
    using System.Collections.Generic;

    public class Server : IServer
    {
        private Dictionary<int, string> serverMessages;
        private int currentId;

        public Server()
        {
            this.serverMessages = new Dictionary<int, string>();
            this.currentId = 1;
        }

        public void SaveInServerDatabase(string message)
        {
            this.serverMessages.Add(currentId, message);
            this.currentId++;
        }
    }
}
