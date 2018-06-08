namespace WebServer.Server.Handlers
{
    using System;
    using Server.HTTP.Contracts;

    public class GetHandler : RequestHandler
    {
        public GetHandler(Func<IHttpContext, IHttpResponse> func) : base(func)
        {
        }
    }
}
