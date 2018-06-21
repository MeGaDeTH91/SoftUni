namespace SimpleMvc.Framework.Attributes.Methods
{
    using System;

    public class HttpPostAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            return requestMethod.ToUpper() == "POST";
        }
    }
}
