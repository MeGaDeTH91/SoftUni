namespace LoggerLibrary.Interfaces
{
    using LoggerLibrary.Enums;
    using System;

    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        ReportLevel ErrorLevel { get; }
    }
}