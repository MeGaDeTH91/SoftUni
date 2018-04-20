namespace Forum.App.Commands
{
    using Contracts;

    public class ViewPostMenuCommand : ICommand
    {
        private ISession session;
        private IMenuFactory menuFactory;

        public ViewPostMenuCommand(ISession session, IMenuFactory menuFactory)
        {
            this.session = session;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            IMenu currentMenu = this.menuFactory.CreateMenu(menuName);

            if (currentMenu is IIdHoldingMenu idHoldingMenu)
            {
                int postId = int.Parse(args[0]);
                idHoldingMenu.SetId(postId);
            }

            return currentMenu;
        }
    }
}
