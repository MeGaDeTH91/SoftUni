namespace LoggerLibrary.Models.Errors
{
    using LoggerLibrary.Interfaces;
    using System;
    using LoggerLibrary.Enums;

    public class Error : IError
    {
        public DateTime DateTime { get; }

        public string Message { get; }

        public ReportLevel ErrorLevel { get; }

        public Error(DateTime dateTime, string message, ReportLevel errorLevel)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.ErrorLevel = errorLevel;
        }
    }
}
