namespace WebServer.ByTheCakeApplication.Controllers
{
    using Server.HTTP.Contracts;
    using Server.HTTP.Response;
    using Server.Enums;
    using Views;
    using Server;

    public class UserController
    {
        public IHttpResponse RegisterGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new RegisterView());
        }

        public IHttpResponse RegisterPost(string name)
        {
            return new RedirectResponse($"/user/{name}");
        }

        public IHttpResponse Details(string name)
        {
            Model model = new Model { ["name"] = name };

            return new ViewResponse(HttpStatusCode.OK, new UserDetailsView(model));
        }
    }
}
