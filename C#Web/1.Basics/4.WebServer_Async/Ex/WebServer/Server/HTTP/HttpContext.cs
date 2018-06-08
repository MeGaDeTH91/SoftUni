namespace WebServer.Server.HTTP
{
    using Contracts;
    using Server.Common;

    public class HttpContext : IHttpContext
    {
        private readonly IHttpRequest request;

        public HttpContext(string requestString)
        {
            DataValidator.ThrowExceptionIfInputIsNull(requestString, nameof(requestString));

            this.request = new HttpRequest(requestString);
        }

        public IHttpRequest Request => this.request;
    }
}
