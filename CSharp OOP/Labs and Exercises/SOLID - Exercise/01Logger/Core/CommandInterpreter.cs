namespace _01Logger.Core
{
    using System;
    using System.Collections.Generic;
    using Appenders;
    using Enums;
    using Factories;
    using Layouts;
    using Loggers;

    public class CommandInterpreter
    {
        private readonly List<IAppender> appenders;
        private ILogger logger;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
        }

        //ILogger logger = new Logger(appenders.ToArray());

        public void Read(string[] args)
        {
            string command = args[0];

            if (command == "Create")
            {
                CreateAppender(args);
            }
            else if (command == "Append")
            {
                logger = new Logger(appenders.ToArray());
                AppendMessage(args);
            }
            else if (command == "END")
            {
                PrintInfo();
            }
        }

        private void PrintInfo()
        {
            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }

        private void CreateAppender(string[] inputInfo)
        {
            string appenderType = inputInfo[1];
            string layoutType = inputInfo[2];
            ReportLevel reportLevel = ReportLevel.INFO;

            if (inputInfo.Length > 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(inputInfo[3], true);
            }

            ILayout layout = LayoutFactory.CreateLayout(layoutType);
            IAppender appender = AppenderFactory.CreateAppender(appenderType, layout, reportLevel);
            appenders.Add(appender);
        }

        private void AppendMessage(string[] inputInfo)
        {
            string loggerMethodType = inputInfo[1];
            string date = inputInfo[2];
            string message = inputInfo[3];

            if (loggerMethodType == "INFO")
            {
                logger.INFO(date, message);
            }
            else if (loggerMethodType == "WARNING")
            {
                logger.WARNING(date, message);
            }
            else if (loggerMethodType == "ERROR")
            {
                logger.ERROR(date, message);
            }
            else if (loggerMethodType == "CRITICAL")
            {
                logger.CRITICAL(date, message);
            }
            else if (loggerMethodType == "FATAL")
            {
                logger.FATAL(date, message);
            }
        }
    }
}
