namespace Forum.App.Commands
{
    using Forum.App.Contracts;

    public class AddReplyCommand : ICommand
    {
        private IMenuFactory menuFacotry;

        public AddReplyCommand(IMenuFactory menuFacotry)
        {
            this.menuFacotry = menuFacotry;
        }

        public IMenu Execute(params string[] args)
        {
            int postId = int.Parse(args[0]);

            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);
            IIdHoldingMenu menu = (IIdHoldingMenu)this.menuFacotry.CreateMenu(menuName + "Menu");

            menu.SetId(postId);

            return menu;
        }
    }
}
