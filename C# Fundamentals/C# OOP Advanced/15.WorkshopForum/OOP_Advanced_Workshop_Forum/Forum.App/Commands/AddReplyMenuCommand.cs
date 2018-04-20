namespace Forum.App.Commands
{
    using Forum.App.Contracts;

    public class AddReplyMenuCommand : ICommand
    {
        private IMenuFactory menuFacotry;

        public AddReplyMenuCommand(IMenuFactory menuFacotry)
        {
            this.menuFacotry = menuFacotry;
        }

        public IMenu Execute(params string[] args)
        {
            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);
            IMenu menu = this.menuFacotry.CreateMenu(menuName);

            return menu;
        }
    }
}
