using LoggerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LoggerLibrary.Models.Layouts
{
    public class JsonLayout : ILayout
    {
        const string DateTimeFormat = "M/d/yyyy h:mm:ss tt";
        const string LayoutFormat = "Date: {0}, ErrorLevel: {1}, Message: {2}";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateTimeFormat, CultureInfo.InvariantCulture);

            return string.Format(LayoutFormat, dateString, error.ErrorLevel, error.Message);
        }
    }
}
