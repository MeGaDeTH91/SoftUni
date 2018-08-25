namespace MyBlog.Common.Helpers
{
    using MyBlog.Common;

    public static class ModifyVideoURL_Embeded
    {
        public static string ModifyEmbed(string inputURL)
        {
            string modifiedLink = inputURL.Replace(CommonConstants.OriginalVideoUrlPart, CommonConstants.ModifiedEmbedURL);

            return modifiedLink;
        }
    }
}
