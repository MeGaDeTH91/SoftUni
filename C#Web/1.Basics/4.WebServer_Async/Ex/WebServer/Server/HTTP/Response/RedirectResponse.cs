namespace WebServer.Server.HTTP.Response
{
    using Server.Common;
    using Server.Enums;

    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl)
        {
            DataValidator.ThrowExceptionIfStringIsNullOrEmpty(redirectUrl, nameof(redirectUrl));

            this.StatusCode = HttpStatusCode.Found;
            this.AddHeader(new HttpHeader("Location", redirectUrl));
        }
    }
}
