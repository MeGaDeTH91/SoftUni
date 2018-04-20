namespace Forum.App.Commands
{
    using System;
    using Forum.App.Contracts;

    public class LogInCommand : ICommand
    {
        private IUserService userService;
        private IMenuFactory menuFactory;

        public LogInCommand(IUserService userService, IMenuFactory menuFactory)
        {
            this.userService = userService;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            string username = args[0];
            string password = args[1];

            bool success = this.userService.TryLogInUser(username, password);

            if (!success)
            {
                throw new InvalidOperationException("Invalid username or password!");
            }

            return this.menuFactory.CreateMenu("MainMenu");
        }
    }
}