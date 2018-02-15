namespace BusTicketSystem.Client.Core
{
    using BusTicketSystem.Client.Core.Commands;
    using System;

    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            string command = commandParameters[0];

            string result = null;

            switch (command.ToLower())
            {
                case "print-info":
                    result = PrintInfoCommand.Execute(commandParameters);
                    break;
                case "buy-ticket":
                    result = BuyTicketCommand.Execute(commandParameters);
                    break;
                case "publish-review":
                    result = PublishReviewCommand.Execute(commandParameters);
                    break;
                case "print-reviews":
                    result = PrintReviewsCommand.Execute(commandParameters);
                    break;
                case "change-trip-status":
                    result = ChangeTripStatusCommand.Execute(commandParameters);
                    break;
                case "exit":
                    result = ExitCommand.Execute(commandParameters);
                    break;

                default:
                    throw new InvalidOperationException($"Command {command} not valid!");
            }
            return result;
        }
    }
}
