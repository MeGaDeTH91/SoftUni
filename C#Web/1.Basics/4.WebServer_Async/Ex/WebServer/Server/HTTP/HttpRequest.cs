namespace WebServer.Server.HTTP
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Server.Common;
    using Server.Enums;
    using Server.Exceptions;
    using Server.HTTP.Contracts;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            DataValidator.ThrowExceptionIfStringIsNullOrEmpty(requestString, nameof(requestString));

            this.HeaderCollection = new HttpHeaderCollection();
            this.UrlParameters = new Dictionary<string, string>();
            this.QueryParameters = new Dictionary<string, string>();
            this.FormData = new Dictionary<string, string>();

            this.ParseRequest(requestString);
        }

        private void ParseRequest(string requestString)
        {
            string[] requestLines = requestString.Split(Environment.NewLine);

            if(requestLines.Length < 1)
            {
                BadRequestException.ThrowInvalidRequestException();
            }

            string[] requestLine = requestLines[0].Trim()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if(requestLine.Length != 3 || requestLine[2].ToLower() != "http/1.1")
            {
                BadRequestException.ThrowInvalidRequestException();
            }

            this.RequestMethod = this.ParseRequestMethod(requestLine[0].ToUpper());
            this.Url = requestLine[1];

            this.Path = this.Url
                .Split(new[] { "?", "#" }, StringSplitOptions.RemoveEmptyEntries)[0];

            this.ParseHeaders(requestLines);

            this.ParseParameters();

            if(this.RequestMethod == HttpRequestMethod.POST)
            {
                this.ParseQuery(requestLines[requestLines.Length - 1], this.FormData);
            }
        }

        private void ParseParameters()
        {
            if (!this.Url.Contains("?"))
            {
                return;
            }

            string query = this.Url.Split("?")[1];

            this.ParseQuery(query, this.QueryParameters);
        }

        private void ParseQuery(string query, Dictionary<string, string> queryParameters)
        {
            if (!query.Contains("="))
            {
                return;
            }

            string[] queryPairs = query.Split("&");

            foreach (var queryPair in queryPairs)
            {
                string[] queryPairArgs = queryPair.Split("=");

                if(queryPairArgs.Length != 2)
                {
                    return;
                }

                string key = WebUtility.UrlDecode(queryPairArgs[0]);
                string value = WebUtility.UrlDecode(queryPairArgs[1]);

                queryParameters.Add(key, value);
            }
        }

        private void ParseHeaders(string[] requestLines)
        {
            int endIndex = Array.IndexOf(requestLines, string.Empty);

            for (int i = 1; i < endIndex; i++)
            {
                string[] headerArgs = requestLines[i].Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

                string headerKey = headerArgs[0];
                string headerValue = headerArgs[1];

                HttpHeader httpHeader = new HttpHeader(headerKey, headerValue);
                this.HeaderCollection.Add(httpHeader);
            }
            if (!this.HeaderCollection.ContainsKey("Host"))
            {
                BadRequestException.ThrowInvalidRequestException();
            }
        }

        private HttpRequestMethod ParseRequestMethod(string requestMethod)
        {
            HttpRequestMethod httpRequestMethod;
            bool requestedMethodIsValid = Enum.TryParse(requestMethod, out httpRequestMethod);

            if (!requestedMethodIsValid)
            {
                BadRequestException.ThrowInvalidRequestException();
            }
            return httpRequestMethod;
        }

        public Dictionary<string, string> FormData { get; private set; }

        public HttpHeaderCollection HeaderCollection { get; private set; }

        public string Path { get; private set; }

        public Dictionary<string, string> QueryParameters { get; private set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, string> UrlParameters { get; private set; }

        public void AddUrlParameter(string key, string value)
        {
            DataValidator.ThrowExceptionIfStringIsNullOrEmpty(key, nameof(key));
            DataValidator.ThrowExceptionIfStringIsNullOrEmpty(value, nameof(value));

            this.UrlParameters[key] = value;
        }
    }
}
