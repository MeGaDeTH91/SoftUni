namespace WebServer.Server.HTTP
{
    using System;
    using System.Collections.Generic;
    using Server.Common;
    using Server.HTTP.Contracts;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            DataValidator.ThrowExceptionIfInputIsNull(header, nameof(header));

            this.headers[header.Key] = header;
        }

        public bool ContainsKey(string key)
        {
            DataValidator.ThrowExceptionIfInputIsNull(key, nameof(key));

            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            DataValidator.ThrowExceptionIfInputIsNull(key, nameof(key));

            if (this.headers.ContainsKey(key))
            {
                return this.headers[key];
            }
            else
            {
                return default(HttpHeader);
            }
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.headers.Values);
        }
    }
}
