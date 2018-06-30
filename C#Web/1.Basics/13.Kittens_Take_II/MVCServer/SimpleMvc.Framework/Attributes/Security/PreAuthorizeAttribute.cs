namespace SimpleMvc.Framework.Attributes.Security
{
    using System;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    [AttributeUsage(AttributeTargets.Method)]
    public class PreAuthorizeAttribute : Attribute
    {
        private const string LoginRoute = "/users/login";

        public virtual IHttpResponse GetResponse(string message)
        {
            return new RedirectResponse(LoginRoute);
        }
    }
}
