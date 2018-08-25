namespace MyBlog.Tests.Helpers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyBlog.App.Helpers.HtmlUtilities;
    using MyBlog.Common.Helpers;
    using MyBlog.Tests.Common;

    [TestClass]
    public class HelpersTests
    {
        [TestMethod]
        public void ModifyVideoURLToEmbed_ShouldWorkCorrectly()
        {
            string inputUrl = TestConstants.Helpers.VideoInputURL;

            string resultUrl = ModifyVideoURL_Embeded.ModifyEmbed(inputUrl);

            Assert.AreEqual(resultUrl, TestConstants.Helpers.VideoExpectedOutputURL);
        }

        [TestMethod]
        public void EncodeForbiddenSymbols_ShouldWorkCorrectly()
        {
            string inputForbidden = TestConstants.Helpers.ForbiddenSymbolsInput;

            string resultString = Html_String_Utility.EncodeThisPropertyForMe(inputForbidden);

            Assert.AreEqual(resultString, TestConstants.Helpers.ForbiddenSymbolsExpectedOutput);
        }

        [TestMethod]
        public void DecodeForbiddenSymbols_ShouldWorkCorrectly()
        {
            string inputForbidden = TestConstants.Helpers.ForbiddenSymbolsExpectedOutput;

            string resultString = Html_String_Utility.DecodeThisPropertyForMe(inputForbidden);

            Assert.AreEqual(resultString, TestConstants.Helpers.ForbiddenSymbolsInput);
        }
    }
}
