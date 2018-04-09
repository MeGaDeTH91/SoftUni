namespace P06_TwitterTest
{
    using NUnit.Framework;
    using P06_Twitter.Contracts;
    using P06_Twitter.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class TwitterTest
    {
        private const int ExpectedMethodInvokedCount = 2;

        [Test]
        public void NullMessageTestShouldThrowException()
        {
            string message = null;

            Type domainType = typeof(Domain);

            IDomain classInstance = (Domain)Activator.CreateInstance(domainType);

            MethodInfo processMessage = domainType.GetMethod("ProcessMessage", BindingFlags.Instance | BindingFlags.Public);

            Assert.That(() => classInstance.ProcessMessage(message), Throws.ArgumentException.With.Message.EqualTo("Invalid message!"));
        }

        [Test]
        public void CheckIfMessageIsWrittenOnConsole()
        {
            string message = "Console_Message_Test_ConsoleBatman";

            Type domainType = typeof(Domain);
            Type clientType = typeof(Client);

            IDomain classInstance = (Domain)Activator.CreateInstance(domainType);

            MethodInfo processMessage = domainType.GetMethod("ProcessMessage", BindingFlags.Instance | BindingFlags.Public);

            //Should Console.WriteLine message;
            processMessage.Invoke(classInstance, new object[] { message });

            IClient clientField = (IClient)domainType.GetField("client", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(classInstance);

            FieldInfo testMessage = clientType.GetField("testIfCorrectMessageIsWrittenOnConsole", BindingFlags.Instance | BindingFlags.NonPublic);

            string checkForProperConsoleWriteLine = testMessage.GetValue(clientField).ToString();

            Assert.That(message, Is.EqualTo(checkForProperConsoleWriteLine));
        }

        [Test]
        public void CheckIfMessageIsStoredInServer()
        {
            string message = "Console Message Test ServerBatman";

            Type domainType = typeof(Domain);
            Type serverType = typeof(Server);

            IDomain classInstance = (Domain)Activator.CreateInstance(domainType);

            MethodInfo processMessage = domainType.GetMethod("ProcessMessage", BindingFlags.Instance | BindingFlags.Public);

            //Should Console.WriteLine message;
            processMessage.Invoke(classInstance, new object[] { message });

            IServer serverField = (IServer)domainType.GetField("server", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(classInstance);

            FieldInfo testMessageServerStorage = serverType.GetField("serverMessages", BindingFlags.Instance | BindingFlags.NonPublic);

            Dictionary<int,string> checkForProperConsoleWriteLine = (Dictionary<int, string>)testMessageServerStorage.GetValue(serverField);

            bool serverContainsMessage = checkForProperConsoleWriteLine.Values.Any(x => x.Equals(message));

            Assert.That(serverContainsMessage, Is.EqualTo(true));
        }

        [Test]
        public void CheckIfInvokedMethodCountIsEqualToTwo()
        {
            string message = "Console Message Test Superman";

            Type domainType = typeof(Domain);
            Type clientType = typeof(Client);

            IDomain classInstance = (Domain)Activator.CreateInstance(domainType);
            MethodInfo proccessMethod = domainType.GetMethod("ProcessMessage", BindingFlags.Instance | BindingFlags.Public);

            proccessMethod.Invoke(classInstance, new object[] { message });

            IClient domainClient = (Client)domainType.GetField("client", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(classInstance);

            int actualCountOfInvokedMethods = (int)clientType.GetField("CountOfInvokedMethods", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(domainClient);

            Assert.That(actualCountOfInvokedMethods, Is.EqualTo(ExpectedMethodInvokedCount));
        }
    }
}
