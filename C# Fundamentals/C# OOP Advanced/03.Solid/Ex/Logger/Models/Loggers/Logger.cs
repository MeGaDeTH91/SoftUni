namespace LoggerLibrary.Models.Loggers
{
    using LoggerLibrary.Interfaces;
    using System.Collections.Generic;

    public class Logger : ILogger
    {
        IEnumerable<IAppender> appenders;

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)appenders;

        public Logger(IEnumerable<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public void Log(IError error)
        {
            foreach (IAppender appender in this.appenders)
            {
                if(appender.ReportLevel <= error.ErrorLevel)
                {
                    appender.Append(error);
                }
            }
        }
    }
}
