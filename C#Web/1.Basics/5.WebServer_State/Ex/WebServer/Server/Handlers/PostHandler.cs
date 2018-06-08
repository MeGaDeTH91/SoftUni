namespace WebServer.Server.Handlers
{
    using System;
    using Server.HTTP.Contracts;

    public class PostHandler : RequestHandler
    {
        public PostHandler(Func<IHttpContext, IHttpResponse> func) : base(func)
        {
        }
    }
}
