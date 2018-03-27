using LoggerLibrary.Factories;
using LoggerLibrary.Interfaces;
using System;

namespace LoggerLibrary.Controller
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger, ErrorFactory errorFactory)
        {
            this.logger = logger;
            this.errorFactory = errorFactory;
        }

        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commTokens = command.Split('|');

                string level = commTokens[0];
                string time = commTokens[1];
                string message = commTokens[2];

                IError error = this.errorFactory.CreateError(time, message, level);
                this.logger.Log(error);
            }

            Console.WriteLine("Logger Info:");
            foreach (IAppender appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }

    }
}
