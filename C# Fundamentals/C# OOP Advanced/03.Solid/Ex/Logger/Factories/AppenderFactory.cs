namespace LoggerLibrary.Factories
{
    using System;
    using LoggerLibrary.Enums;
    using LoggerLibrary.Interfaces;
    using LoggerLibrary.Models.Appenders;
    using LoggerLibrary.Models.Loggers;

    public class AppenderFactory
    {
        const string DefaultNameOfFile = "LogFileNumber{0}.txt";
        private LayoutFactory layoutFactory;
        private int fileNumber;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
            this.fileNumber = 0;
        }

        public IAppender CreateAppender(string appenderType, string layoutType, string errorLevel)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            ReportLevel reportLevel = this.ParseLevelOfError(errorLevel);
            IAppender appender = null;

            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, reportLevel);
                    break;
                case "FileAppender":
                    ILogFile file = new LogFile(string.Format(DefaultNameOfFile, this.fileNumber));
                    this.fileNumber += 1;
                    appender = new FileAppender(layout, reportLevel, file);
                    break;
                default:
                    throw new ArgumentException("Invalid Appender Type!");
            }
            return appender;
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
