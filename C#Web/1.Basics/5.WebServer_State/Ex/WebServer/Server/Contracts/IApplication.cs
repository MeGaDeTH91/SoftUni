﻿namespace WebServer.Server.Contracts
{
    using Server.Routing.Contracts;

    public interface IApplication
    {
        void Start(IAppRouteConfig appRouteConfig);
    }
}
