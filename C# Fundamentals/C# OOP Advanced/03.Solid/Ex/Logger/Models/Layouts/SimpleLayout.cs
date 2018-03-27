namespace LoggerLibrary.Models.Layouts
{
    using LoggerLibrary.Interfaces;
    using System.Globalization;

    public class SimpleLayout : ILayout
    {
        //<date-time> - <report level> - <message>
        const string DateTimeFormat = "M/d/yyyy h:mm:ss tt";
        const string Format = "{0} - {1} - {2}";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateTimeFormat, CultureInfo.InvariantCulture);

            return string.Format(Format, dateString, error.ErrorLevel, error.Message);
        }
    }
}
