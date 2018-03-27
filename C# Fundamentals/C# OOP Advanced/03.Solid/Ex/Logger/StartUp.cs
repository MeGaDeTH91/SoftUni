namespace LoggerLibrary
{
    using LoggerLibrary.Controller;
    using LoggerLibrary.Enums;
    using LoggerLibrary.Factories;
    using LoggerLibrary.Interfaces;
    using LoggerLibrary.Models.Appenders;
    using LoggerLibrary.Models.Errors;
    using LoggerLibrary.Models.Layouts;
    using LoggerLibrary.Models.Loggers;
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            ErrorFactory errorFactory = new ErrorFactory();
            ILogger logger = InitializeLogger();
            Engine engine = new Engine(logger, errorFactory);

            engine.Run();
        }

        static ILogger InitializeLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

            int numberOfAppenders = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfAppenders; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string appenderType = tokens[0];
                string layoutType = tokens[1];
                //Default ErrorLevel => INFO
                string levelOfError = "INFO";

                if(tokens.Length == 3)
                {
                    levelOfError = tokens[2];
                }
                IAppender appender = appenderFactory.CreateAppender(appenderType, layoutType,  levelOfError);

                appenders.Add(appender);
            }
            ILogger logger = new Logger(appenders);

            return logger;
        }
    }
}
