namespace WebServer.ByTheCakeApplication.Views.Home
{
    using Server.Contracts;

    public class HomeIndexView : IView
    {
        public string View()
        {
            return 
                "<h1>By the Cake</h1>"
                + "<h2>Enjoy our awesome cakes</h2>"
                + "<hr />";
        }
    }
}
