namespace WebServer.Server.Handlers
{
    using System;
    using Handlers.Contracts;
    using HTTP.Contracts;
    using Server.HTTP;

    public abstract class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpContext, IHttpResponse> func;

        protected RequestHandler(Func<IHttpContext, IHttpResponse> func)
        {
            this.func = func;
        }

        public IHttpResponse Handle(IHttpContext httpContext)
        {
            IHttpResponse httpResponse = this.func.Invoke(httpContext);

            httpResponse.AddHeader(new HttpHeader("Content-Type", "text/html"));

            return httpResponse;
        }
    }
}
