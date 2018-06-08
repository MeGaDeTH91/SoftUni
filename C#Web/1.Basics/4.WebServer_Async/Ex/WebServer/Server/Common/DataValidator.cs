namespace WebServer.Server.Common
{
    using System;

    public class DataValidator
    {
        public static void ThrowExceptionIfInputIsNull(object obj, string name)
        {
            if(obj == null)
            {
                throw new ArgumentException(name);
            }
        }

        public static void ThrowExceptionIfStringIsNullOrEmpty(string textToValidate, string name)
        {
            if (string.IsNullOrEmpty(textToValidate))
            {
                throw new ArgumentException($"{name} cannot be null or empty.");
            }
        }
    }
}
