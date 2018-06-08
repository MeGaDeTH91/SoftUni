namespace WebServer.ByTheCakeApplication.Controllers
{
    using Server.HTTP.Contracts;
    using Server.HTTP.Response;
    using Server.Enums;
    using Views.Home;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            return new ViewResponse(HttpStatusCode.OK, new HomeIndexView());
        }
    }
}
