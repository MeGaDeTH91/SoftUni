using LoggerLibrary.Enums;
using LoggerLibrary.Interfaces;
using LoggerLibrary.Models.Errors;
using System;
using System.Globalization;

namespace LoggerLibrary.Factories
{
    public class ErrorFactory
    {
        const string DateTimeFormat = "M/d/yyyy h:mm:ss tt";

        public IError CreateError(string dateString, string message, string reportLevel)
        {
            DateTime dateTime = DateTime.ParseExact(dateString, DateTimeFormat, CultureInfo.InvariantCulture);
            ReportLevel errorLevel = ParseLevelOfError(reportLevel);
            IError error = new Error(dateTime, message, errorLevel);

            return error;
        }

        private ReportLevel ParseLevelOfError(string errorLevel)
        {
            ReportLevel levelOfError;
            bool validReportLevel = Enum.TryParse<ReportLevel>(errorLevel, out levelOfError);

            if (!validReportLevel)
            {
                throw new ArgumentException("Invalid ErrorLevel!");
            }

            return levelOfError;
        }
    }
}
