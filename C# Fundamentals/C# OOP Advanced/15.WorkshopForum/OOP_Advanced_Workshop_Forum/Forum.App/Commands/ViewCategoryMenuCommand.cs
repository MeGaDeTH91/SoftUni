namespace Forum.App.Commands
{
    using Forum.App.Contracts;

    public class ViewCategoryMenuCommand : ICommand
    {
        private IMenuFactory menuFacotry;

        public ViewCategoryMenuCommand(IMenuFactory menuFacotry)
        {
            this.menuFacotry = menuFacotry;
        }

        public IMenu Execute(params string[] args)
        {
            int categoryId = int.Parse(args[0]);
            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);
            IIdHoldingMenu menu = (IIdHoldingMenu)this.menuFacotry.CreateMenu(menuName);
            menu.SetId(categoryId);

            return menu;
        }
    }
}
