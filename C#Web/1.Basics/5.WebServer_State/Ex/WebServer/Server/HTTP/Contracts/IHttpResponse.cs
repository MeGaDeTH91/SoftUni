namespace WebServer.Server.HTTP.Contracts
{
    using Server.Contracts;
    using Server.Enums;

    public interface IHttpResponse
    {
        HttpHeaderCollection HeaderCollection { get; }

        HttpStatusCode StatusCode { get; }

        void AddHeader(HttpHeader header);
    }
}
