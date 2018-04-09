namespace P06_Twitter
{
    using P06_Twitter.Contracts;
    using P06_Twitter.Models;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    class StartUp
    {
        static void Main(string[] args)
        {
            string message = "Console Message Test ServerBatman";

            Type domainType = typeof(Domain);
            Type serverType = typeof(Server);

            Domain classInstance = (Domain)Activator.CreateInstance(domainType);

            MethodInfo processMessage = domainType.GetMethod("ProcessMessage", BindingFlags.Instance | BindingFlags.Public);

            //Should Console.WriteLine message;
            processMessage.Invoke(classInstance, new object[] { message });

            IServer serverField = (IServer)domainType.GetField("server", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(classInstance);

            FieldInfo testMessageServerStorage = serverType.GetField("serverMessages", BindingFlags.Instance | BindingFlags.NonPublic);

            Dictionary<int, string> checkForProperConsoleWriteLine = (Dictionary<int, string>)testMessageServerStorage.GetValue(serverField);


        }
    }
}
