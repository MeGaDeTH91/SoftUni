﻿namespace WebServer
{
    using System;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Http;
    using Http.Contracts;
    using Http.Response;
    using Common;
    using Contracts;

    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IHandleable mvcRequestHandler;

        private readonly IHandleable fileHandler;

        public ConnectionHandler(
            Socket client,
            IHandleable mvcRequestHandler,
            IHandleable fileHandler)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(mvcRequestHandler, nameof(mvcRequestHandler));
            CoreValidator.ThrowIfNull(fileHandler, nameof(fileHandler));

            this.client = client;
            this.mvcRequestHandler = mvcRequestHandler;
            this.fileHandler = fileHandler;
        }

        public async Task ProcessRequestAsync()
        {
            var httpRequest = await this.ReadRequest();

            if (httpRequest != null)
            {
                var httpResponse = HandleRequest(httpRequest);

                await PrepareResponse(httpResponse);

                Console.WriteLine($"-----REQUEST-----");
                Console.WriteLine(httpRequest);
                Console.WriteLine($"-----RESPONSE-----");
                Console.WriteLine(httpResponse);
                Console.WriteLine();
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<IHttpRequest> ReadRequest()
        {
            var result = new StringBuilder();

            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int numberOfBytesRead = await this.client.ReceiveAsync(data.Array, SocketFlags.None);

                if (numberOfBytesRead == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);

                result.Append(bytesAsString);

                if (numberOfBytesRead < 1023)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            return new HttpRequest(result.ToString());
        }

        private IHttpResponse HandleRequest(IHttpRequest httpRequest)
        {
            IHttpResponse httpResponse;
            if (httpRequest.Path.Contains("."))
            {
                httpResponse = this.fileHandler.Handle(httpRequest);
            }
            else
            {
                string sessionId = this.SetRequestSession(httpRequest);
                httpResponse = this.mvcRequestHandler.Handle(httpRequest);
                this.SetResponseSession(httpResponse, sessionId);
            }

            return httpResponse;
        }

        private string SetRequestSession(IHttpRequest request)
        {
            if (!request.Cookies.ContainsKey(SessionStore.SessionCookieKey))
            {
                var sessionId = Guid.NewGuid().ToString();

                request.Session = SessionStore.Get(sessionId);

                return sessionId;
            }

            return null;
        }

        private void SetResponseSession(IHttpResponse response, string sessionIdToSend)
        {
            if (sessionIdToSend != null)
            {
                response.Headers.Add(
                    HttpHeader.SetCookie,
                    $"{SessionStore.SessionCookieKey}={sessionIdToSend}; HttpOnly; path=/");
            }
        }

        private async Task PrepareResponse(IHttpResponse httpResponse)
        {
            var responseBytes = Encoding.UTF8.GetBytes(httpResponse.ToString()).ToList();
            if (httpResponse is FileResponse)
            {
                responseBytes.AddRange((httpResponse as FileResponse).FileData);
            }

            var byteSegments = new ArraySegment<byte>(responseBytes.ToArray());

            await this.client.SendAsync(byteSegments, SocketFlags.None);
        }
    }
}