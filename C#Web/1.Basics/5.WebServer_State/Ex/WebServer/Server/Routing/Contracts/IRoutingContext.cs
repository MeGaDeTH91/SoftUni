﻿namespace WebServer.Server.Routing.Contracts
{
    using System;
    using System.Collections.Generic;
    using Server.Handlers;

    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        RequestHandler RequestHandler { get; }
    }
}
