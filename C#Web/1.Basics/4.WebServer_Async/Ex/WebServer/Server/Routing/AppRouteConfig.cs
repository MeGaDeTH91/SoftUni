namespace WebServer.Server.Routing
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Enums;
    using Handlers;
    using Server.Common;

    public class AppRouteConfig : IAppRouteConfig
    {
        private Dictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> routes;

        public AppRouteConfig()
        {
            this.routes = new Dictionary<HttpRequestMethod, Dictionary<string, RequestHandler>>();

            foreach (HttpRequestMethod request in Enum.GetValues(typeof(HttpRequestMethod)))
            {
                this.routes.Add(request, new Dictionary<string, RequestHandler>());
            }
        }

        public IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes => this.routes;

        public void AddRoute(string route, RequestHandler httpHandler)
        {
            DataValidator.ThrowExceptionIfInputIsNull(route, nameof(route));
            DataValidator.ThrowExceptionIfInputIsNull(httpHandler, nameof(httpHandler));

            if (httpHandler.GetType().ToString().ToLower().Contains("get"))
            {
                this.routes[HttpRequestMethod.GET].Add(route, httpHandler);
            }
            else if (httpHandler.GetType().ToString().ToLower().Contains("post"))
            {
                this.routes[HttpRequestMethod.POST].Add(route, httpHandler);
            }
        }
    }
}
