namespace Forum.App.Commands
{
    using Forum.App.Contracts;

    public class AddPostMenuCommand : ICommand
    {
        private IMenuFactory menuFacotry;

        public AddPostMenuCommand(IMenuFactory menuFacotry)
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
