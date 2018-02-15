namespace TeamBuilder.Client
{
    using System.Linq;
    using System;
    using TeamBuilder.Client.Core.Commands;

    public class CommandDispatcher
    {
        public string Dispatch(string input)
        {
            string result = string.Empty;

            string[] inputArgs = input.Split(new[] { ' ', '\t' },StringSplitOptions.RemoveEmptyEntries);

            string commandName = inputArgs.Length > 0 ? inputArgs[0] : string.Empty;

            inputArgs = inputArgs.Skip(1).ToArray();

            switch (commandName.ToLower())
            {
                case "registeruser":
                    RegisterUserCommand registerUser = new RegisterUserCommand();
                    result = registerUser.Execute(inputArgs);
                    break;
                case "login":
                    LoginCommand login = new LoginCommand();
                    result = login.Execute(inputArgs);
                    break;
                case "logout":
                    LogoutCommand logout = new LogoutCommand();
                    result = logout.Execute(inputArgs);
                    break;
                case "deleteuser":
                    DeleteUserCommand delete = new DeleteUserCommand();
                    result = delete.Execute(inputArgs);
                    break;
                case "createevent":
                    CreateEventCommand createEvent = new CreateEventCommand();
                    result = createEvent.Execute(inputArgs);
                    break;
                case "createteam":
                    CreateTeamCommand createTeam = new CreateTeamCommand();
                    result = createTeam.Execute(inputArgs);
                    break;
                case "invitetoteam":
                    InviteToTeamCommand inviteToTeam = new InviteToTeamCommand();
                    result = inviteToTeam.Execute(inputArgs);
                    break;
                case "acceptinvite":
                    AcceptInviteCommand acceptInvite = new AcceptInviteCommand();
                    result = acceptInvite.Execute(inputArgs);
                    break;
                case "declineinvite":
                    DeclineInviteCommand declineInvite = new DeclineInviteCommand();
                    result = declineInvite.Execute(inputArgs);
                    break;
                case "kickmember":
                    KickMemberCommand kickMember = new KickMemberCommand();
                    result = kickMember.Execute(inputArgs);
                    break;
                case "disband":
                    DisbandCommand disband = new DisbandCommand();
                    result = disband.Execute(inputArgs);
                    break;
                case "addteamto":
                    AddTeamToCommand addTeamTo = new AddTeamToCommand();
                    result = addTeamTo.Execute(inputArgs);
                    break;
                case "showevent":
                    ShowEventCommand showEvent = new ShowEventCommand();
                    result = showEvent.Execute(inputArgs);
                    break;
                case "showteam":
                    ShowTeamCommand showTeam = new ShowTeamCommand();
                    result = showTeam.Execute(inputArgs);
                    break;
                case "exit":
                    ExitCommand exit = new ExitCommand();
                    exit.Execute(inputArgs);
                    break;
                default:
                    throw new NotSupportedException($"Command {commandName} not supported!");
            }

            return result;
        }
    }
}
