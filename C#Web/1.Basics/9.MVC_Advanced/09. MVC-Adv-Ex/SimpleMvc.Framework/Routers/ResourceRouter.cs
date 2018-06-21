namespace SimpleMvc.Framework.Routers
{
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using WebServer.Contracts;
    using WebServer.Enums;
    using WebServer.Exceptions;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ResourceRouter : IHandleable
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            string fileFullName = request.Path.Split("/").Last();
            string fileExtension = request.Path.Split(".").Last();

            IHttpResponse fileResponse = null;

            try
            {
                byte[] fileContent = this.ReadFileContent(fileFullName, fileExtension);

                fileResponse = new FileResponse(HttpStatusCode.Found, fileContent);
            }
            catch (Exception e)
            {
                return new NotFoundResponse();
            }

            return fileResponse;
        }

        private byte[] ReadFileContent(string fileFullName, string fileExtension)
        {
            byte[] byteContent = File.ReadAllBytes(string.Format(
                "{0}\\{1}\\{2}",
                MvcContext.Get.ResourcesFolder,
                fileExtension,
                fileFullName));
            
            return byteContent;
        }
    }
}
