namespace WebServer.Server.Routing
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Handlers;

    public class RoutingContext : IRoutingContext
    {
        public RoutingContext(IEnumerable<string> parameters, RequestHandler requestHandler)
        {
            this.Parameters = parameters;
            this.RequestHandler = requestHandler;
        }

        public IEnumerable<string> Parameters { get; private set; }

        public RequestHandler RequestHandler { get; private set; }
    }
}
