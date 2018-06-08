namespace WebServer.Server.HTTP.Response
{
    using Contracts;
    using Server.Contracts;
    using Server.Common;
    using Server.Enums;
    using System.Text;

    public abstract class HttpResponse : IHttpResponse
    {
        protected HttpResponse()
        {
            this.HeaderCollection = new HttpHeaderCollection();
        }

        public HttpHeaderCollection HeaderCollection { get; private set; }

        public HttpStatusCode StatusCode { get; protected set; }

        public void AddHeader(HttpHeader header)
        {
            DataValidator.ThrowExceptionIfStringIsNullOrEmpty(header.Key, nameof(header.Key));
            DataValidator.ThrowExceptionIfStringIsNullOrEmpty(header.Value, nameof(header.Value));

            this.HeaderCollection.Add(header);
        }

        private string statusCodeMessage => this.StatusCode.ToString();

        public override string ToString()
        {
            StringBuilder response = new StringBuilder();

            int statusCodeNumber = (int)this.StatusCode;
            response.AppendLine($"HTTP/1.1 {statusCodeNumber} {this.statusCodeMessage}");

            response.AppendLine(this.HeaderCollection.ToString());
            response.AppendLine();
            
            return response.ToString();
        }
    }
}
