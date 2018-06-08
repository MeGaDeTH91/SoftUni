namespace WebServer.Server.HTTP
{
    using System;
    using Server.Common;

    public class HttpHeader
    {
        public HttpHeader(string key, string value)
        {
            DataValidator.ThrowExceptionIfStringIsNullOrEmpty(key, nameof(key));
            DataValidator.ThrowExceptionIfStringIsNullOrEmpty(value, nameof(value));

            this.Key = key;
            this.Value = value;
        }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public override string ToString()
        {
            return this.Key + ": " + this.Value;
        }
    }
}
