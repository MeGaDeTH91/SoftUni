﻿namespace WebServer.Application.Controllers
{
    using Server.HTTP.Contracts;
    using Server.HTTP.Response;
    using Server.Enums;
    using Application.Views;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            return new ViewResponse(HttpStatusCode.OK, new HomeIndexView());
        }
    }
}
