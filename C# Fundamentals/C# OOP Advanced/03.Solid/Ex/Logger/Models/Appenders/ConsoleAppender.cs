namespace LoggerLibrary.Models.Appenders
{
    using LoggerLibrary.Interfaces;
    using System;
    using LoggerLibrary.Enums;

    public class ConsoleAppender : IAppender
    {
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; }

        public int MessagesAppended { get; private set; }

        public ConsoleAppender(ILayout layout, ReportLevel reportLevel)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
            this.MessagesAppended = 0;
        }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            Console.WriteLine(formattedError);
            this.MessagesAppended += 1;
        }
        public override string ToString()
        {
            string appenderType = this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;

            string endResult = $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesAppended}";

            return endResult;
        }
    }
}
