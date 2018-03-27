namespace LoggerLibrary.Models.Layouts
{
    using LoggerLibrary.Interfaces;
    using System.Globalization;
    using System.Text;

    public class XmlLayout : ILayout
    {
        const string DateTimeFormat = "M/d/yyyy h:mm:ss tt";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<log>");
            sb.AppendLine($"<date>{dateString}</date>");
            sb.AppendLine($"<level>{error.ErrorLevel}</level>");
            sb.AppendLine($"<message>{error.Message}</message>");
            sb.AppendLine("</log>");

            return sb.ToString().TrimEnd();
        }
    }
}
