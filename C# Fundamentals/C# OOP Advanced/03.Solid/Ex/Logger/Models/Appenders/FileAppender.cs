namespace LoggerLibrary.Models.Appenders
{
    using LoggerLibrary.Interfaces;
    using System;
    using LoggerLibrary.Enums;

    public class FileAppender : IAppender
    {
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; }

        private ILogFile File { get; }

        public int MessagesAppended { get; private set; }

        public FileAppender(ILayout layout, ReportLevel reportLevel, ILogFile file)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
            this.File = file;
            this.MessagesAppended = 0;
        }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            this.File.WriteLogToFile(formattedError);

            this.MessagesAppended += 1;
        }
        public override string ToString()
        {
            string appenderType = this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;

            string endResult = $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesAppended}, File size: {this.File.Size}";

            return endResult;
        }
    }
}
