﻿namespace WebServer.Http.Response
{
    using Enums;
    using Exceptions;
    using Contracts;
    using System;

    public class FileResponse : HttpResponse
    {
        public FileResponse(HttpStatusCode statusCode, byte[] fileData)
        {
            this.ValidateStatusCode(statusCode);

            this.FileData = fileData;
            this.StatusCode = statusCode;

            this.Headers.Add(HttpHeader.ContentLength, this.FileData.Length.ToString());
            this.Headers.Add(HttpHeader.ContentDisposition, "attachment");
        }

        public byte[] FileData { get; }

        private void ValidateStatusCode(HttpStatusCode statusCode)
        {
            var statusCodeNumber = (int)statusCode;

            if(299 < statusCodeNumber && statusCodeNumber < 400)
            {
                throw new InvalidResponseException("File responses need a status code above 300 and below 400");
            }

            //if (statusCodeNumber >= 300 || statusCodeNumber < 400)
            //{
            //    throw new InvalidResponseException("File responses need a status code below 300 and above 400");
            //}
        }

    }
}
