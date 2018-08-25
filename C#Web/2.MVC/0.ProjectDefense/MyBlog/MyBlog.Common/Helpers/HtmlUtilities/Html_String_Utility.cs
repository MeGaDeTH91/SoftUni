namespace MyBlog.App.Helpers.HtmlUtilities
{
    using System.Web;

    public static class Html_String_Utility
    {
        public static string EncodeThisPropertyForMe(string property)
        {
            return HttpUtility.HtmlEncode(property);
        }

        public static string DecodeThisPropertyForMe(string property)
        {
            return HttpUtility.HtmlDecode(property);
        }
    }
}
