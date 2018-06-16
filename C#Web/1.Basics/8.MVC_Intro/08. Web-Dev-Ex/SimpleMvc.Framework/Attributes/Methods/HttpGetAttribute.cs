namespace SimpleMvc.Framework.Attributes.Methods
{
    using System;

    public class HttpGetAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if(requestMethod == "GET")
            {
                return true;
            }
            return false;
        }
    }
}
