namespace WebServer.Http.Response
{
    using System;
    using Enums;

    public class UnauthorizedResponse : HttpResponse
    {
        public UnauthorizedResponse(string message)
        {
            this.StatusCode = HttpStatusCode.NotAuthorized;
        }
    }
}
